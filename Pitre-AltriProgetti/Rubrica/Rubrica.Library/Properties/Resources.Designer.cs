﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rubrica.Library.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Rubrica.Library.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Utente non autorizzato ad effettuare l&apos;operazione richiesta.
        /// </summary>
        internal static string AuthorizationException {
            get {
                return ResourceManager.GetString("AuthorizationException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attenzione, Codice Fiscale non corretto!.
        /// </summary>
        internal static string CodiceFiscaleException {
            get {
                return ResourceManager.GetString("CodiceFiscaleException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non è stato possibile salvare i dati in quanto potrebbero essere stati modificati da un altro utente.
        /// </summary>
        internal static string ConcurrencyException {
            get {
                return ResourceManager.GetString("ConcurrencyException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dato non presente con l&apos;identificativo indicato.
        /// </summary>
        internal static string DataNotFoundException {
            get {
                return ResourceManager.GetString("DataNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nella rimozione dell&apos;elemento in rubrica.
        /// </summary>
        internal static string DeleteElementoRubricaException {
            get {
                return ResourceManager.GetString("DeleteElementoRubricaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nella rimozione dell&apos;utente in rubrica.
        /// </summary>
        internal static string DeleteUserException {
            get {
                return ResourceManager.GetString("DeleteUserException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Il codice &apos;{0}&apos; risulta già presente e non può essere duplicato.
        /// </summary>
        internal static string ElementoRubricaAlreadyExistException {
            get {
                return ResourceManager.GetString("ElementoRubricaAlreadyExistException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nel reperimento dell&apos;elemento rubrica con Id {0}.
        /// </summary>
        internal static string GetElementoRubricaException {
            get {
                return ResourceManager.GetString("GetElementoRubricaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nel reperimento dell&apos;utente in rubrica con Id {0}.
        /// </summary>
        internal static string GetUserException {
            get {
                return ResourceManager.GetString("GetUserException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nell&apos;inserimento dell&apos;elemento in rubrica.
        /// </summary>
        internal static string InsertElementoRubricaException {
            get {
                return ResourceManager.GetString("InsertElementoRubricaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nell&apos;inserimento dell&apos;utente in rubrica.
        /// </summary>
        internal static string InsertUserException {
            get {
                return ResourceManager.GetString("InsertUserException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Credenziali utente non valide.
        /// </summary>
        internal static string InvalidCredentialsException {
            get {
                return ResourceManager.GetString("InvalidCredentialsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Indirizzo mail &apos;{0}&apos; non valido.
        /// </summary>
        internal static string MailAddressNotValidException {
            get {
                return ResourceManager.GetString("MailAddressNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La dimensione massima per il campo {0} è di {1} caratteri.
        /// </summary>
        internal static string MaxFieldLenghtException {
            get {
                return ResourceManager.GetString("MaxFieldLenghtException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dato mancante: {0}.
        /// </summary>
        internal static string MissingFieldException {
            get {
                return ResourceManager.GetString("MissingFieldException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attenzione, Partita Iva non corretta!.
        /// </summary>
        internal static string PartitaIvaException {
            get {
                return ResourceManager.GetString("PartitaIvaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provider &apos;{0}&apos; non supportato.
        /// </summary>
        internal static string ProviderNotSupportedException {
            get {
                return ResourceManager.GetString("ProviderNotSupportedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rubrica.
        /// </summary>
        internal static string RubricaDatabaseName {
            get {
                return ResourceManager.GetString("RubricaDatabaseName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nella ricerca degli elementi in rubrica.
        /// </summary>
        internal static string SearchElementiRubricaException {
            get {
                return ResourceManager.GetString("SearchElementiRubricaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nella ricerca degli utenti in rubrica.
        /// </summary>
        internal static string SearchUserException {
            get {
                return ResourceManager.GetString("SearchUserException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nell&apos;aggiornamento dell&apos;elemento in rubrica.
        /// </summary>
        internal static string UpdateElementoRubricaException {
            get {
                return ResourceManager.GetString("UpdateElementoRubricaException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nell&apos;aggiornamento dell&apos;utente in rubrica.
        /// </summary>
        internal static string UpdateUserException {
            get {
                return ResourceManager.GetString("UpdateUserException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nella modifica della password per l&apos;utente in rubrica.
        /// </summary>
        internal static string UpdateUserPwdException {
            get {
                return ResourceManager.GetString("UpdateUserPwdException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Url &apos;{0}&apos; non valido.
        /// </summary>
        internal static string UrlNotValidException {
            get {
                return ResourceManager.GetString("UrlNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Impossibile effettuare l&apos;operazione richiesta. Utente in uso.
        /// </summary>
        internal static string UserAccountInUse {
            get {
                return ResourceManager.GetString("UserAccountInUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to L&apos;utente &apos;{0}&apos; risulta già presente e non può essere duplicato.
        /// </summary>
        internal static string UserAlreadyException {
            get {
                return ResourceManager.GetString("UserAlreadyException", resourceCulture);
            }
        }
    }
}
