USE [PCM_DEPOSITO_FINGER]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ========================================================
-- Author:		Giovanni Olivari
-- Create date: 24/05/2013
-- Description:	Esegue l'analisi per il Versamento indicato
-- ========================================================
ALTER PROCEDURE [DOCSADM].[sp_ARCHIVE_BE_StartAnalysisForTransfer]
	@TransferID int
AS
BEGIN
	DECLARE @COPIA VARCHAR(20)= 'COPIA'
	DECLARE @TRASFERIMENTO VARCHAR(20)= 'TRASFERIMENTO'
	
	DECLARE @log VARCHAR(2000)
	DECLARE @logType VARCHAR(10)
	DECLARE @logObject VARCHAR(50) = OBJECT_NAME(@@PROCID)
	DECLARE @logObjectType_Transfer int = 1 -- 'Transfer'
	DECLARE @logObjectID int = @TransferID
	DECLARE @errorCode int
	
	DECLARE @transferState int
	DECLARE @transferState_IN_DEFINIZIONE int = 1 -- IN DEFINIZIONE
	DECLARE @transferState_ANALISI_COMPLETATA int = 2 -- ANALISI COMPLETATA


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	-- Verifica che il versamento sia nello stato IN DEFINIZIONE, altrimenti non può essere avviata l'analisi
	--
	SELECT @transferState=TRANSFERSTATETYPE_ID FROM
	(
	SELECT TS.TRANSFER_ID, TS.TRANSFERSTATETYPE_ID, TS.DATETIME
	, RN = ROW_NUMBER() OVER (PARTITION BY TS.TRANSFER_ID ORDER BY TS.DATETIME DESC)
	FROM ARCHIVE_TRANSFERSTATE TS
	WHERE TS.TRANSFER_ID = @TransferID
	) T
	WHERE T.RN = 1
		
	print 'Stato IN_DEFINIZIONE: ' + CAST(@transferState_IN_DEFINIZIONE AS NVARCHAR(MAX))
	print 'Stato Transfer: ' + CAST(@transferState AS NVARCHAR(MAX))
		
	IF (@transferState <> @transferState_IN_DEFINIZIONE)
	BEGIN
		set @logType = 'ERROR'
		set @log = 'Transfer in stato non compatibile con l''avvio dell''analisi - TransferID: ' + CAST(@TransferID AS NVARCHAR(MAX))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END



	BEGIN TRANSACTION T1



	-- *********
	-- DOCUMENTI
	-- *********
	
	

	-- Aggiorna a TRASFERIMENTO tutti i documenti delle policy appartenenti al transfer corrente.
	-- Vengono prese in considerazione soltanto le policy abilitate e in stato 
	-- RICERCA COMPLETATA/ANALISI IN CORSO/ANALISI COMPLETATA
	--
	UPDATE ARCHIVE_TempProfile 
	SET 
		TipoTrasferimento_Versamento = @TRASFERIMENTO,
		CopiaPerCatenaDoc_Versamento = 0,
		CopiaPerFascicolo_Versamento = 0,
		CopiaPerConservazione_Versamento = 0
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento documenti per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento documenti per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID



    -- Fascicoli
    -- Un documento è in COPIA se:
    --		- è contenuto in un fascicolo procedimentale che non è presente nel DB di Deposito
    --      oppure
    --		- è contenuto in un fascicolo procedimentale che non è presente nelle policy del versamento
	--
	UPDATE ARCHIVE_TEMPPROFILE 
	SET 
		TipoTrasferimento_Versamento = @COPIA,
		CopiaPerFascicolo_Versamento = 1
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	AND PROFILE_ID IN
		(
		SELECT DISTINCT TDF.PROFILE_ID--, F.SYSTEM_ID ID_PROJECT_DEP, TF.PROJECT_ID ID_PROJECT_VERS, TDF.PROJECT_ID
		FROM ARCHIVE_TEMP_PROJECT_PROFILE TDF 
		LEFT OUTER JOIN PROJECT F ON TDF.PROJECT_ID = F.SYSTEM_ID -- Fascicoli già presenti nel DB del Deposito
		LEFT OUTER JOIN ARCHIVE_TEMPPROJECT TF ON TDF.PROJECT_ID = TF.PROJECT_ID -- Fascicoli della policy corrente
		WHERE TDF.TRANSFERPOLICY_ID IN
			(
			SELECT SYSTEM_ID 
			FROM ARCHIVE_TRANSFERPOLICY
			WHERE TRANSFER_ID = @TransferID
			AND ENABLED = 1
			AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
			)
		AND ISNULL(F.CHA_TIPO_FASCICOLO,'') != 'G'
		--AND (F.SYSTEM_ID IS NULL AND TF.PROJECT_ID IS NULL AND NOT TDF.PROJECT_ID IS NULL) -- è in copia se è in un procedimentale che non porto con il versamento E NON È nel deposito
		AND (F.SYSTEM_ID IS NULL OR (NOT TF.PROJECT_ID IS NULL AND TF.DATRASFERIRE = 0))
		)
		
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento documenti (Copia per fascicoli) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento documenti (Copia per fascicoli) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID
		

    
    -- Catene doc
    -- Un documento è in COPIA se:
    --		- il collegato non è già nel DB di Deposito 
    --		- il collegato non è nelle policy del versamento
	--
	UPDATE ARCHIVE_TEMPPROFILE 
	SET 
		TipoTrasferimento_Versamento = @COPIA,
		CopiaPerCatenaDoc_Versamento = 1
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	AND PROFILE_ID IN
		(
		SELECT distinct Profile_ID FROM
		(
		-- Documenti che fanno parte di catene per le policy del versamento
		SELECT PROFILE_ID, LINKEDDOC_ID FROM ARCHIVE_TEMPCATENEDOC 
		WHERE TRANSFERPOLICY_ID IN
			(
			SELECT SYSTEM_ID 
			FROM ARCHIVE_TRANSFERPOLICY
			WHERE TRANSFER_ID = @TransferID
			AND ENABLED = 1
			AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
			)
		UNION
		SELECT LINKEDDOC_ID, PROFILE_ID PROFILE_ID FROM ARCHIVE_TEMPCATENEDOC 
		WHERE TRANSFERPOLICY_ID IN
			(
			SELECT SYSTEM_ID 
			FROM ARCHIVE_TRANSFERPOLICY
			WHERE TRANSFER_ID = @TransferID
			AND ENABLED = 1
			AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
			)
		) T
		WHERE LINKEDDOC_ID NOT IN 
			(
			SELECT PROFILE_ID FROM ARCHIVE_TEMPPROFILE 
			WHERE TRANSFERPOLICY_ID IN
				(
				SELECT SYSTEM_ID 
				FROM ARCHIVE_TRANSFERPOLICY
				WHERE TRANSFER_ID = @TransferID
				AND ENABLED = 1
				AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
				)
			)
		AND LINKEDDOC_ID NOT IN 
			(
			SELECT SYSTEM_ID FROM PROFILE
			)
		)
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento documenti (Copia per catene doc) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento documenti (Copia per catene doc) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID


	    
    -- In conservazione
    --
	UPDATE ARCHIVE_TempProfile 
	SET 
		TipoTrasferimento_Versamento = @COPIA,
		CopiaPerConservazione_Versamento = 1
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	AND INCONSERVAZIONE = 1
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento documenti (Copia per conservazione) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento documenti (Copia per conservazione) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID
    


    -- Reset del flag MantieniCopia (per tutte le Policy del Versamento)
    --
	UPDATE ARCHIVE_TempProfile 
	SET MantieniCopia = 0
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		)
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del flag MantieniCopia per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento flag MantieniCopia per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

    
    
    -- *********
    -- FASCICOLI
    -- *********
    
    
    
	-- Aggiorna a TRASFERIMENTO tutti i fascicoli delle policy appartenenti al transfer corrente.
	-- Vengono prese in considerazione soltanto le policy abilitate e in stato 
	-- RICERCA COMPLETATA/ANALISI IN CORSO/ANALISI COMPLETATA
	--
	UPDATE ARCHIVE_TempProject 
	SET 
		TipoTrasferimento_Versamento = @TRASFERIMENTO
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento (fascicoli) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento (fascicoli) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID


	    
    -- In conservazione
    --
	UPDATE ARCHIVE_TempProject
	SET 
		TipoTrasferimento_Versamento = @COPIA
	WHERE TRANSFERPOLICY_ID IN
		(
		SELECT SYSTEM_ID 
		FROM ARCHIVE_TRANSFERPOLICY
		WHERE TRANSFER_ID = @TransferID
		AND ENABLED = 1
		AND TRANSFERPOLICYSTATE_ID IN (3,4,5)
		)
	AND INCONSERVAZIONE = 1
	
	set @errorCode = @@ERROR

	IF @errorCode <> 0
	BEGIN
		-- Rollback the transaction
		ROLLBACK
		
		set @logType = 'ERROR'
		set @log = 'Errore durante l''aggiornamento del tipo trasferimento fascicoli (Copia per conservazione) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX)) + ' - Codice errore: ' + CAST(@errorCode AS NVARCHAR(8))
		
		EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID

		-- Raise an error and return
		RAISERROR (@log, 16, 1)
		RETURN
	END
	
	set @logType = 'INFO'
	set @log = 'Aggiornamento tipo trasferimento fascicoli (Copia per conservazione) per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID



	-- Aggiorna lo stato del versamento a ANALISI COMPLETATA
	--	
	DECLARE	@return_value int,
		@System_ID int,
		@now datetime = getDate()

	EXEC	@return_value = [sp_ARCHIVE_Insert_TransferState]
			@Transfer_ID = @TransferID,
			@TransferStateType_ID = @transferState_ANALISI_COMPLETATA, -- ANALISI COMPLETATA
			@System_ID = @System_ID OUTPUT
			
	set @logType = 'INFO'
	set @log = 'Aggiornamento stato a ANALISI COMPLETATA per il Transfer: ' + CAST(@TransferID AS NVARCHAR(MAX))
	EXECUTE sp_ARCHIVE_BE_InsertLog @log, @logType, @logObject, @logObjectType_Transfer, @logObjectID
    
    
    
	COMMIT TRANSACTION T1
    
END
