using System;
namespace APMAN.Core.Helper
{
    public interface IInformationHelper
    {
        public void SendMessageToKafka(string message,string topicName = "");
        public void SendMail();
        
    }
}
