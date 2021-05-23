using System;
namespace APMAN.Core.Types
{
    public class KafkaCommon
    {
        /// <summary>
        /// servisler arası iletişim
        /// </summary>
        public const string servicestopic = "apmanservices";
        /// <summary>
        /// mesaj topic'i
        /// </summary>
        public const string messagetopic = "messagetopic";
        /// <summary>
        /// döküman haberleşmesi
        /// </summary>
        public const string apmandivit = "apmandivit";
        /// <summary>
        /// frontend bilgilendirme
        /// </summary>
        public const string browsertopic = "browser";
    }
}
