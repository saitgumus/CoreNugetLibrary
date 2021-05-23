using System;
using Confluent.Kafka;
using Kafka.Public;

namespace APMAN.Core.Infrastructure.Kafka
{
    public class ConsumerWrapper
    {
        private string _topicName;
        private ConsumerConfig _consumerConfig;
        private IConsumer<Null, string> _consumer;

        public ConsumerWrapper(string topicName)
        {
            this._topicName = topicName;
            this._consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                GroupId="apman"
            };

            this._consumer = new ConsumerBuilder<Null, string>(_consumerConfig).Build();
            this._consumer.Subscribe(topicName);
        }

        public string readMessage()
        {
            var consumeResult = this._consumer.Consume();
            return consumeResult.Message.Value;
        }
    }
}
