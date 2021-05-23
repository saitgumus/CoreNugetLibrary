namespace SG.Kernel.Types
{
    public class Common
    {
        /// <summary>
        /// hata kodlarını bulunduran yapıdır.
        /// </summary>
        public struct ErrorCodes
        {
            /// <summary>
            /// kullanıcı uyarı
            /// </summary>
            public const string UserWarning = "USERWARNING";
            /// <summary>
            /// kullanıcı hata
            /// </summary>
            public const string UserError = "USERERROR";
            /// <summary>
            /// yanlış kullanıcı parolası
            /// </summary>
            public const string WrongPassword = "USERWRONGPASSWORD";
            /// <summary>
            /// kaynak yönetimi hataları
            /// </summary>
            public const string AuthError = "AUTHERROR";

        }
        /// <summary>
        /// default hata mesajları
        /// </summary>
        public struct ErrorMessages
        {
            public const string CouldNotConnectedDb = "Veri tabanına bağlanılamadı.";
            /// <summary>
            /// parola çözümlenemedi (hash - salt)
            /// </summary>
            public const string CanNotSplitPassHash = "Parola çözümlenemedi.";
            /// <summary>
            /// token oluşturulamadı
            /// </summary>
            public const string CanNotCreateToken = "Token oluşturulamadı.";
        }
        
        /// <summary>
        /// default uyarı mesajları
        /// </summary>
        public struct WarningMessages
        {
            /// <summary>
            /// kullanıcı daha önce kaydedilmiş.
            /// </summary>
            public const string UserAllReadyExist = "Kullanıcı daha önceden kaydedilmiş.";
            /// <summary>
            /// yanlış / geçersiz parola
            /// </summary>
            public const string WrongPassword = "Parola Yanlış";
        }

        /// <summary>
        /// hash ve salt stringleri için ayraç görevindedir.
        /// </summary>
        public const char HashToSaltSeparator = '~';

    }
    
    /// <summary>
    /// veri tabanı
    /// </summary>
    public struct DataBases
    {
        public const string APMAN = "APMAN";
    }

    
}