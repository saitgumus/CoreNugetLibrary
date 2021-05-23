using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Public;
using Serilog;
using static Confluent.Kafka.ConfigPropertyNames;

namespace APMAN.Core.Infrastructure.Kafka
{
    public class ProducerWrapper
    {
        private string _topicName;
        ProducerConfig _config;
        private IProducer<Null, string> _producer;
        private static readonly Random rnd = new Random();

        /// <summary>
        /// kafka producer
        /// </summary>
        /// <param name="topicName">string</param>
        /// <param name="config"> ProduceConfig</param>
        public ProducerWrapper(string topicName,ProducerConfig config)
        {
            this._topicName = topicName;
            this._config = config;
            //    new ProducerConfig
            //{
            //    BootstrapServers = "localhost:9092"
            //};
            this._producer = new ProducerBuilder<Null, string>(_config).Build();

        }

        /// <summary>
        /// kafka servisine mesaj gönderir
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task writeMessage(string message)
        {
                var dr = await _producer.ProduceAsync(topic:_topicName, new Message<Null, string> { Value = message });
                Log.Information($"KAFKA => Delivered Message:'{dr.Value}' to '{dr.TopicPartitionOffset}' ");

            return;
        }
    }
}
