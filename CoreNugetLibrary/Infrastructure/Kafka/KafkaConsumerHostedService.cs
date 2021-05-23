using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APMAN.Core.Types;
using Kafka.Public;
using Kafka.Public.Loggers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SG.Kernel.Infrastructure.Kafka
{
    public class KafkaConsumerHostedService : IHostedService
    {
        private readonly ILogger<KafkaConsumerHostedService> logger;
        private readonly ClusterClient clusterClient;
        public string Topic { get; private set; } = KafkaCommon.messagetopic;

        public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger)
        {
            this.logger = logger;
            this.clusterClient = new ClusterClient(new Configuration
            {
                Seeds = "localhost:9092"
            }, new ConsoleLogger());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            clusterClient.ConsumeFromLatest(Topic);
            clusterClient.MessageReceived += ClusterClient_MessageReceived;

            return Task.CompletedTask;
        }

        private void ClusterClient_MessageReceived(RawKafkaRecord obj)
        {
            this.logger.LogInformation($"Received: {Encoding.UTF8.GetString(obj.Value as byte[])}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            clusterClient?.Dispose();
            return Task.CompletedTask;
        }
    }
}
