﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Models
{
    public class LoggingOptions
    {
        private List<LogFields> loggingFields;
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public string LoggerCategoryName { get; set; } = "RequestResponseLoggingMiddleware";
        public List<LogFields> LoggingFields
        {
            get 
            {
                return loggingFields ??= new List<LogFields>();
            }

            set => loggingFields = value;
        }
    }

    public enum LogFields
    {
        Request,
        Response,
        HostName,
        Path,
        QueryString,
        ResponseTiming,
        RequestLength,
        ResponseLength
    }
}
