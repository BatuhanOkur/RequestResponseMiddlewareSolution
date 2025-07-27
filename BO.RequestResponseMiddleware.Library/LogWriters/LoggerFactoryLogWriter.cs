using BO.RequestResponseMiddleware.Library.Interfaces;
using BO.RequestResponseMiddleware.Library.MessageCreators;
using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.LogWriters
{
    internal class LoggerFactoryLogWriter : ILogWriter
    {
        private readonly ILogger logger;
        private readonly LoggingOptions loggingOptions;
        public ILogMessageCreator MessageCreator { get; set; }

        internal LoggerFactoryLogWriter(ILoggerFactory loggerFactory, LoggingOptions loggingOptions)
        {
            this.logger = loggerFactory.CreateLogger(loggingOptions.LoggerCategoryName);
            this.loggingOptions = loggingOptions;

            MessageCreator = new LoggerFactoryMessageCreator(loggingOptions);
        }

        public async Task Write(RequestResponseContext context)
        {
            var message = MessageCreator.Create(context);
            logger.Log(loggingOptions.LogLevel, message);

            await Task.CompletedTask;
        }
    }
}
