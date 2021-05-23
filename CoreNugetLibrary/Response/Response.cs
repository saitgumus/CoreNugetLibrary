using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SG.Kernel.Response
{
    public class Response<T>
    {
        Microsoft.Extensions.Logging.ILogger _logger;
        public bool Success { get; private set; } = true;
        public T Value { get; set; }
        public List<Result> Results { get; private set; }
        public Response(Microsoft.Extensions.Logging.ILogger logger =null)
        {
            Success = true;
            this._logger = logger;
            Log.Information("Response serilog from core test.");
        }

        public void AddResults(params Result[] result)
        {
            if (Results == null)
                this.Results = new List<Result>();
            Results.AddRange(result);
            this.Success = false;
            LogError();
        }

        public void AddResults(List<Result> resultList)
        {
            if (Results == null)
                this.Results = new List<Result>();
            Results.AddRange(resultList);
            this.Success = false;
            LogError();
        }

        private void LogError()
        {
            if(_logger != null && Results != null)
            {
                foreach (var item in Results)
                {
                    if(item.Severity == Severity.Lower)
                        _logger.LogWarning(item.ErrorMessage);
                    else
                        _logger.LogError(item.ErrorMessage);
                }
            }
        }

        public void GenerateAndAddResult(string errorCode,string message,Severity severity)
        {
            AddResults(new Result()
            {
                ErrorCode = errorCode,
                ErrorMessage = message,
                Severity = severity
            });
        }
    }
}