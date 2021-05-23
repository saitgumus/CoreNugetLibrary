using System;
using Microsoft.Extensions.Logging;

namespace SG.Kernel.Events
{
    [System.Serializable]
    public sealed class LogEventArgs : EventArgs
    {
        public string Message { get; set; }
        public LogEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
