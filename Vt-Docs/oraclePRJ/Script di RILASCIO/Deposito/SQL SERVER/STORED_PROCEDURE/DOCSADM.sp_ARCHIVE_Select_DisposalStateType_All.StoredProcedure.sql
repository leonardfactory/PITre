USE [PCM_DEPOSITO_1]
GO
/****** Object:  StoredProcedure [DOCSADM].[sp_ARCHIVE_Select_DisposalStateType_All]    Script Date: 08/14/2013 11:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC   [DOCSADM].[sp_ARCHIVE_Select_DisposalStateType_All] 
AS
BEGIN
SELECT [ARCHIVE_DisposalStateType].[System_ID], [ARCHIVE_DisposalStateType].[Name] 
FROM [DOCSADM].[ARCHIVE_DisposalStateType]
END
GO
