using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace DocsPAWA.popup
{
	/// <summary>
	/// Summary description for visualStampaReg.
	/// </summary>
    public class visualStampaReg : DocsPAWA.CssPage
	{
		private string id;
		protected DocsPAWA.DocsPaWR.InfoDocumento infoDoc;
		protected DocsPAWA.DocsPaWR.SchedaDocumento schedaDoc;

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=-1;
			DocsPaWR.FileDocumento theDoc = null;

			if(Session["docToSign"]==null) 
			{
				id = Request["id"];
				if (!(id != null && !id.Equals("")))
					id = Session.SessionID;
				
				theDoc = FileManager.getInstance(id).getFile(this);
			}
			else 
			{
				theDoc = (DocsPAWA.DocsPaWR.FileDocumento) Session["docToSign"];
			}

			if (theDoc != null) 
			{
				Response.ContentType="application/pdf";
				Response.AddHeader("content-disposition", "inline;filename=" + theDoc.name);
				Response.AddHeader("content-lenght", theDoc.content.Length.ToString());				
				Response.BinaryWrite(theDoc.content);
			}
			
		}
		
			



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
