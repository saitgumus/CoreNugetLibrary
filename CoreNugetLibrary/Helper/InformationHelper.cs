using System;
using APMAN.Core.Helper;
using APMAN.Core.Infrastructure.Kafka;
using APMAN.Core.Types;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace APMAN.Core.Helper
{
    /// <summary>
    /// bilgilendirme (mail-mesaj vs.) helper
    /// </summary>
    public class InformationHelper : IInformationHelper
    {
        private string topic = KafkaCommon.servicestopic;
        private ProducerConfig _producerConfig;
        private ProducerWrapper produceWrapper;
        
        public InformationHelper(ProducerConfig configuration)
        {
            _producerConfig = configuration;
            this.produceWrapper = new ProducerWrapper(topic,_producerConfig);
        }

        public void SendMail()
        {
            throw new NotImplementedException();
        }

        public void SendMessageToKafka(string message,string topicName = "")
        {
            if(!string.IsNullOrEmpty(topicName) && this.topic.Trim() != topicName.Trim())
            {
                this.topic = topicName.Trim();
                this.produceWrapper = new ProducerWrapper(this.topic, this._producerConfig);
            }
            _ = produceWrapper.writeMessage(message);   
        }

    }
}
