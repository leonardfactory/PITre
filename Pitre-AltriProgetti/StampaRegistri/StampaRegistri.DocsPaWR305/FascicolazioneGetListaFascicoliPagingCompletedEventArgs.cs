using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace StampaRegistri.DocsPaWR305
{
	[GeneratedCode("System.Web.Services", "2.0.50727.42"), DesignerCategory("code"), DebuggerStepThrough]
	public class FascicolazioneGetListaFascicoliPagingCompletedEventArgs : AsyncCompletedEventArgs
	{
		private object[] results;

		public Fascicolo[] Result
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (Fascicolo[])this.results[0];
			}
		}

		public int numTotPage
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[1];
			}
		}

		public int nRec
		{
			get
			{
				base.RaiseExceptionIfNecessary();
				return (int)this.results[2];
			}
		}

		internal FascicolazioneGetListaFascicoliPagingCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : base(exception, cancelled, userState)
		{
			this.results = results;
		}
	}
}