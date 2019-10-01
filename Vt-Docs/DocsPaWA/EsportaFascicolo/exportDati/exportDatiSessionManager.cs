using System;

namespace DocsPAWA.exportDati
{
	/// <summary>
	/// Summary description for exportDatiSessionManager.
	/// </summary>
	public class exportDatiSessionManager
	{
		private const string EXPORT_FILE_SESSION = "EXPORT_FILE_SESSION";

		public exportDatiSessionManager()
		{
			
		}

		#region FILE
		/// <summary>
		/// Imposta la sessione dell'export
		/// </summary>
		public void SetSessionExportFile(DocsPAWA.DocsPaWR.FileDocumento file)
		{
			if (System.Web.HttpContext.Current.Session[EXPORT_FILE_SESSION]==null)
			{
				System.Web.HttpContext.Current.Session.Add(EXPORT_FILE_SESSION,file);
			}
		}

		/// <summary>
		/// Recupera l'export in sessione
		/// </summary>
		/// <returns></returns>
		public DocsPAWA.DocsPaWR.FileDocumento GetSessionExportFile()
		{
			DocsPaWR.FileDocumento filePdf = new DocsPAWA.DocsPaWR.FileDocumento();

			if (System.Web.HttpContext.Current.Session[EXPORT_FILE_SESSION]!=null)
			{			
				filePdf = (DocsPAWA.DocsPaWR.FileDocumento) System.Web.HttpContext.Current.Session[EXPORT_FILE_SESSION];
			}
			return filePdf;
		}
		
		/// <summary>
		/// Rilascia la sessione dell'export
		/// </summary>
		public void ReleaseSessionExportFile()
		{
			System.Web.HttpContext.Current.Session.Remove(EXPORT_FILE_SESSION);
		}
		#endregion


	}
}