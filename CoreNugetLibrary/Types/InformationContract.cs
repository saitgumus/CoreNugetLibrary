using System;
namespace SG.Kernel.Types
{
    public class InformationContract
    {
        public InformationContract()
        {
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
