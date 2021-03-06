USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_Update_TransferState_PK]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_Update_TransferState_PK]  ( @Transfer_ID int , @TransferStateType_ID int , @DateTime datetime , @System_ID int, @RowsAffected int out )
AS
BEGIN
UPDATE [DOCSADM].[ARCHIVE_TransferState]
SET  [Transfer_ID] = @Transfer_ID,
[TransferStateType_ID] = @TransferStateType_ID,
[DateTime] = @DateTime 
WHERE ( [System_ID] = @System_ID )
set @RowsAffected= @@ROWCOUNT
END
GO
