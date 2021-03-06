﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1008.
// 
#pragma warning disable 1591

namespace RubricaComune.Proxy.Elementi {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RubricaServicesSoap", Namespace="http://valueteam.com/rubrica")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CriterioRicerca[]))]
    public partial class RubricaServices : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private SecurityCreadentialsSoapHeader securityCreadentialsSoapHeaderValueField;
        
        private System.Threading.SendOrPostCallback SearchOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateMulticasellaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RubricaServices() {
            this.Url = "http://localhost/Rubrica/RubricaServices.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public SecurityCreadentialsSoapHeader SecurityCreadentialsSoapHeaderValue {
            get {
                return this.securityCreadentialsSoapHeaderValueField;
            }
            set {
                this.securityCreadentialsSoapHeaderValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SearchCompletedEventHandler SearchCompleted;
        
        /// <remarks/>
        public event GetCompletedEventHandler GetCompleted;
        
        /// <remarks/>
        public event InsertCompletedEventHandler InsertCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        public event UpdateMulticasellaCompletedEventHandler UpdateMulticasellaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Search", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ElementoRubrica[] Search(ref OpzioniRicerca opzioniRicerca) {
            object[] results = this.Invoke("Search", new object[] {
                        opzioniRicerca});
            opzioniRicerca = ((OpzioniRicerca)(results[1]));
            return ((ElementoRubrica[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchAsync(OpzioniRicerca opzioniRicerca) {
            this.SearchAsync(opzioniRicerca, null);
        }
        
        /// <remarks/>
        public void SearchAsync(OpzioniRicerca opzioniRicerca, object userState) {
            if ((this.SearchOperationCompleted == null)) {
                this.SearchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchOperationCompleted);
            }
            this.InvokeAsync("Search", new object[] {
                        opzioniRicerca}, this.SearchOperationCompleted, userState);
        }
        
        private void OnSearchOperationCompleted(object arg) {
            if ((this.SearchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompleted(this, new SearchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Get", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ElementoRubrica Get(int id) {
            object[] results = this.Invoke("Get", new object[] {
                        id});
            return ((ElementoRubrica)(results[0]));
        }
        
        /// <remarks/>
        public void GetAsync(int id) {
            this.GetAsync(id, null);
        }
        
        /// <remarks/>
        public void GetAsync(int id, object userState) {
            if ((this.GetOperationCompleted == null)) {
                this.GetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOperationCompleted);
            }
            this.InvokeAsync("Get", new object[] {
                        id}, this.GetOperationCompleted, userState);
        }
        
        private void OnGetOperationCompleted(object arg) {
            if ((this.GetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCompleted(this, new GetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Insert", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ElementoRubrica Insert(ElementoRubrica elemento) {
            object[] results = this.Invoke("Insert", new object[] {
                        elemento});
            return ((ElementoRubrica)(results[0]));
        }
        
        /// <remarks/>
        public void InsertAsync(ElementoRubrica elemento) {
            this.InsertAsync(elemento, null);
        }
        
        /// <remarks/>
        public void InsertAsync(ElementoRubrica elemento, object userState) {
            if ((this.InsertOperationCompleted == null)) {
                this.InsertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertOperationCompleted);
            }
            this.InvokeAsync("Insert", new object[] {
                        elemento}, this.InsertOperationCompleted, userState);
        }
        
        private void OnInsertOperationCompleted(object arg) {
            if ((this.InsertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertCompleted(this, new InsertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Update", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ElementoRubrica Update(ElementoRubrica elemento) {
            object[] results = this.Invoke("Update", new object[] {
                        elemento});
            return ((ElementoRubrica)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(ElementoRubrica elemento) {
            this.UpdateAsync(elemento, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(ElementoRubrica elemento, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        elemento}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Delete", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Delete(ElementoRubrica elemento) {
            this.Invoke("Delete", new object[] {
                        elemento});
        }
        
        /// <remarks/>
        public void DeleteAsync(ElementoRubrica elemento) {
            this.DeleteAsync(elemento, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(ElementoRubrica elemento, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        elemento}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/UpdateMulticasella", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ElementoRubrica UpdateMulticasella(ElementoRubrica elemento) {
            object[] results = this.Invoke("UpdateMulticasella", new object[] {
                        elemento});
            return ((ElementoRubrica)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateMulticasellaAsync(ElementoRubrica elemento) {
            this.UpdateMulticasellaAsync(elemento, null);
        }
        
        /// <remarks/>
        public void UpdateMulticasellaAsync(ElementoRubrica elemento, object userState) {
            if ((this.UpdateMulticasellaOperationCompleted == null)) {
                this.UpdateMulticasellaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateMulticasellaOperationCompleted);
            }
            this.InvokeAsync("UpdateMulticasella", new object[] {
                        elemento}, this.UpdateMulticasellaOperationCompleted, userState);
        }
        
        private void OnUpdateMulticasellaOperationCompleted(object arg) {
            if ((this.UpdateMulticasellaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateMulticasellaCompleted(this, new UpdateMulticasellaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://valueteam.com/rubrica", IsNullable=false)]
    public partial class SecurityCreadentialsSoapHeader : System.Web.Services.Protocols.SoapHeader {
        
        private string userNameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class UrlInfo {
        
        private string urlField;
        
        /// <remarks/>
        public string Url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class EmailInfo {
        
        private string emailField;
        
        private string noteField;
        
        private bool preferitaField;
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public string Note {
            get {
                return this.noteField;
            }
            set {
                this.noteField = value;
            }
        }
        
        /// <remarks/>
        public bool Preferita {
            get {
                return this.preferitaField;
            }
            set {
                this.preferitaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class ElementoRubrica {
        
        private string canaleField;
        
        private int idField;
        
        private string codiceField;
        
        private string descrizioneField;
        
        private string indirizzoField;
        
        private string telefonoField;
        
        private string faxField;
        
        private string cittaField;
        
        private string capField;
        
        private string provinciaField;
        
        private string nazioneField;
        
        private string emailField;
        
        private EmailInfo[] emailsField;
        
        private string amministrazioneField;
        
        private string aOOField;
        
        private string utenteCreatoreField;
        
        private System.DateTime dataCreazioneField;
        
        private System.DateTime dataUltimaModificaField;
        
        private Tipo tipoCorrispondenteField;
        
        private UrlInfo[] urlsField;
        
        private string cHA_PubblicatoField;
        
        private string codiceFiscaleField;
        
        private string partitaIvaField;
        
        /// <remarks/>
        public string Canale {
            get {
                return this.canaleField;
            }
            set {
                this.canaleField = value;
            }
        }
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Codice {
            get {
                return this.codiceField;
            }
            set {
                this.codiceField = value;
            }
        }
        
        /// <remarks/>
        public string Descrizione {
            get {
                return this.descrizioneField;
            }
            set {
                this.descrizioneField = value;
            }
        }
        
        /// <remarks/>
        public string Indirizzo {
            get {
                return this.indirizzoField;
            }
            set {
                this.indirizzoField = value;
            }
        }
        
        /// <remarks/>
        public string Telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <remarks/>
        public string Fax {
            get {
                return this.faxField;
            }
            set {
                this.faxField = value;
            }
        }
        
        /// <remarks/>
        public string Citta {
            get {
                return this.cittaField;
            }
            set {
                this.cittaField = value;
            }
        }
        
        /// <remarks/>
        public string Cap {
            get {
                return this.capField;
            }
            set {
                this.capField = value;
            }
        }
        
        /// <remarks/>
        public string Provincia {
            get {
                return this.provinciaField;
            }
            set {
                this.provinciaField = value;
            }
        }
        
        /// <remarks/>
        public string Nazione {
            get {
                return this.nazioneField;
            }
            set {
                this.nazioneField = value;
            }
        }
        
        /// <remarks/>
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public EmailInfo[] Emails {
            get {
                return this.emailsField;
            }
            set {
                this.emailsField = value;
            }
        }
        
        /// <remarks/>
        public string Amministrazione {
            get {
                return this.amministrazioneField;
            }
            set {
                this.amministrazioneField = value;
            }
        }
        
        /// <remarks/>
        public string AOO {
            get {
                return this.aOOField;
            }
            set {
                this.aOOField = value;
            }
        }
        
        /// <remarks/>
        public string UtenteCreatore {
            get {
                return this.utenteCreatoreField;
            }
            set {
                this.utenteCreatoreField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataCreazione {
            get {
                return this.dataCreazioneField;
            }
            set {
                this.dataCreazioneField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataUltimaModifica {
            get {
                return this.dataUltimaModificaField;
            }
            set {
                this.dataUltimaModificaField = value;
            }
        }
        
        /// <remarks/>
        public Tipo TipoCorrispondente {
            get {
                return this.tipoCorrispondenteField;
            }
            set {
                this.tipoCorrispondenteField = value;
            }
        }
        
        /// <remarks/>
        public UrlInfo[] Urls {
            get {
                return this.urlsField;
            }
            set {
                this.urlsField = value;
            }
        }
        
        /// <remarks/>
        public string CHA_Pubblicato {
            get {
                return this.cHA_PubblicatoField;
            }
            set {
                this.cHA_PubblicatoField = value;
            }
        }
        
        /// <remarks/>
        public string CodiceFiscale {
            get {
                return this.codiceFiscaleField;
            }
            set {
                this.codiceFiscaleField = value;
            }
        }
        
        /// <remarks/>
        public string PartitaIva {
            get {
                return this.partitaIvaField;
            }
            set {
                this.partitaIvaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public enum Tipo {
        
        /// <remarks/>
        UO,
        
        /// <remarks/>
        RF,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriterioOrdinamento {
        
        private string nomeField;
        
        private TipiOrdinamentoEnum tipoField;
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public TipiOrdinamentoEnum Tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public enum TipiOrdinamentoEnum {
        
        /// <remarks/>
        Asc,
        
        /// <remarks/>
        Desc,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriOrdinamento {
        
        private CriterioOrdinamento[] criteriField;
        
        /// <remarks/>
        public CriterioOrdinamento[] Criteri {
            get {
                return this.criteriField;
            }
            set {
                this.criteriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriPaginazione {
        
        private int paginaField;
        
        private int oggettiPerPaginaField;
        
        private int totalePagineField;
        
        private int totaleOggettiField;
        
        /// <remarks/>
        public int Pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
            }
        }
        
        /// <remarks/>
        public int OggettiPerPagina {
            get {
                return this.oggettiPerPaginaField;
            }
            set {
                this.oggettiPerPaginaField = value;
            }
        }
        
        /// <remarks/>
        public int TotalePagine {
            get {
                return this.totalePagineField;
            }
            set {
                this.totalePagineField = value;
            }
        }
        
        /// <remarks/>
        public int TotaleOggetti {
            get {
                return this.totaleOggettiField;
            }
            set {
                this.totaleOggettiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriterioRicerca {
        
        private TipiRicercaParolaEnum tipoRicercaField;
        
        private string nomeField;
        
        private object valoreField;
        
        /// <remarks/>
        public TipiRicercaParolaEnum TipoRicerca {
            get {
                return this.tipoRicercaField;
            }
            set {
                this.tipoRicercaField = value;
            }
        }
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public object Valore {
            get {
                return this.valoreField;
            }
            set {
                this.valoreField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public enum TipiRicercaParolaEnum {
        
        /// <remarks/>
        ParolaIntera,
        
        /// <remarks/>
        ParteDellaParola,
        
        /// <remarks/>
        ParolaIniziaCon,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriRicerca {
        
        private CriterioRicerca[] criteriField;
        
        /// <remarks/>
        public CriterioRicerca[] Criteri {
            get {
                return this.criteriField;
            }
            set {
                this.criteriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1015")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class OpzioniRicerca {
        
        private CriteriRicerca criteriRicercaField;
        
        private CriteriPaginazione criteriPaginazioneField;
        
        private CriteriOrdinamento criteriOrdinamentoField;
        
        /// <remarks/>
        public CriteriRicerca CriteriRicerca {
            get {
                return this.criteriRicercaField;
            }
            set {
                this.criteriRicercaField = value;
            }
        }
        
        /// <remarks/>
        public CriteriPaginazione CriteriPaginazione {
            get {
                return this.criteriPaginazioneField;
            }
            set {
                this.criteriPaginazioneField = value;
            }
        }
        
        /// <remarks/>
        public CriteriOrdinamento CriteriOrdinamento {
            get {
                return this.criteriOrdinamentoField;
            }
            set {
                this.criteriOrdinamentoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SearchCompletedEventHandler(object sender, SearchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ElementoRubrica[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ElementoRubrica[])(this.results[0]));
            }
        }
        
        /// <remarks/>
        public OpzioniRicerca opzioniRicerca {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OpzioniRicerca)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCompletedEventHandler(object sender, GetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ElementoRubrica Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ElementoRubrica)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertCompletedEventHandler(object sender, InsertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ElementoRubrica Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ElementoRubrica)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ElementoRubrica Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ElementoRubrica)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DeleteCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateMulticasellaCompletedEventHandler(object sender, UpdateMulticasellaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateMulticasellaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateMulticasellaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ElementoRubrica Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ElementoRubrica)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591