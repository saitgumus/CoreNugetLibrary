using System;
using System.Threading;
using System.Threading.Tasks;
using APMAN.Core.Helper;
using APMAN.Core.Types;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SG.Kernel.Infrastructure.Kafka
{
    public class KafkaProducerHostedService : BackgroundService
    {
        public ProducerConfig config { get; set; }
        public ILogger<KafkaProducerHostedService> logger { get; set; }
        private IProducer<Null, string> producer;
        public string Topic { get; private set; } = KafkaCommon.servicestopic;

        public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
        {
            config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            this.logger = logger;
            producer = new ProducerBuilder<Null, string>(config).Build();
        }


        //public override Task StartAsync(CancellationToken cancellationToken)
        //{
        //    logger.LogInformation("kafka producer başlatıldı");
        //    return Task.CompletedTask;
        //    for (int i = 0; i < 50; i++)
        //    {
        //        logger.LogInformation("kafka producer başlatıldı");
        //        //await producer.ProduceAsync(Topic, new Message<Null, string>()
        //        //{
        //        //    Value = "hello world" + i.ToString()
        //        //}, cancellationToken);
        //        //producer.Flush(TimeSpan.FromSeconds(10));
        //    }
        //}

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            producer?.Dispose();
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await producer.ProduceAsync(Topic, new Message<Null, string>()
            {
                Value = "executed producer"
            }, stoppingToken);
            producer.Flush(TimeSpan.FromSeconds(10));

        }
    }
}
