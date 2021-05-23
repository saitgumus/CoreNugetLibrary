using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace APMAN.Core.Helper
{
    public class InfrastructureHelper
    {
        public event EventHandler ProducingMessage;

        private ILogger logger;

        public InfrastructureHelper(ILogger logger)
        {
            this.logger = logger;
        }

        public Task ProduceMessage(string message)
        {
            if(ProducingMessage != null)
            {
                ProducingMessage.Invoke(message, EventArgs.Empty);
            }
           return Task.CompletedTask;
        }


    }

    [Serializable]
    public sealed class InfrastructureEventArgs : EventArgs
    {
        private string message;

        public InfrastructureEventArgs(string message)
        {
            this.message = message;
        }
    }

}
