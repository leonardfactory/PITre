USE [GFD_SVIL]
GO
/****** Object:  StoredProcedure [DOCSADM].[RemoveTransModelVisibileToRole]    Script Date: 03/08/2013 11:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [DOCSADM].[RemoveTransModelVisibileToRole] 
    -- Id corr globali del ruolo di cui eleminare i modelli
@roleCorrBGlobId     INT  AS

/******************************************************************************
   NAME:       RemoveTransModelVisibileToRole
   AUTHOR:     Samuele Furnari
   PURPOSE:    Store procedure per la cancellazione di modelli di trasmissione
               visibili solo al ruolo con id corr globali pari a quello
               passato per parametro

******************************************************************************/

begin   

   DECLARE @idModello INT
   DECLARE @countIdModello INT

-- Cursore per scorrere sugli id di modelli di trasmissione che hanno 
-- esattamente un solo mittente.
   DECLARE @models CURSOR
   DECLARE @SWV_error INT

       -- Apertura cursore
   SET @models = CURSOR  FOR select md.ID_MODELLO, count(*) as numMitt
   from dpa_modelli_mitt_dest md
   where md.CHA_TIPO_MITT_DEST = 'M' and md.ID_CORR_GLOBALI = @roleCorrBGlobId
   group by md.id_modello order by md.ID_MODELLO
   open @models

   while 1 = 1
   begin
      fetch @models into @idModello,@countIdModello
      if @@FETCH_STATUS <> 0
      BREAK
      if @countIdModello = 1
      begin
            -- Cancellazione delle righe della DPA_MODELLI_DEST_CON_NOTIFICA
         delete dpa_modelli_dest_con_notifica where id_modello = @idModello

            -- Cancellazione delle righe della DPA_MODELLI_MITT_DEST
         delete dpa_modelli_mitt_dest where id_modello = @idModello

            -- Cancellazione della tupla da DPA_MODELLI_TRASM
         delete dpa_modelli_trasm where system_id = @idModello
      end
   end

   CLOSE @models

END 
