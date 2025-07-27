using BO.RequestResponseMiddleware.Library.Interfaces;
using BO.RequestResponseMiddleware.Library.LogWriters;
using BO.RequestResponseMiddleware.Library.Middlewares;
using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddBORequestResponseMiddleware(this IApplicationBuilder appBuilder,
            Action<RequestResponseOptions> optionAction) 
        {
            var opt = new RequestResponseOptions();
            optionAction(opt);

            ILogWriter logWriter = opt.LoggerFactory is null ? new NullLogWriter() :
                new LoggerFactoryLogWriter(opt.LoggerFactory, opt.LoggingOptions);

            if (opt.ReqResHandler is not null)
                appBuilder.UseMiddleware<HandlerRequestResponseLoggingMiddleware>(opt.ReqResHandler, logWriter);
            else
                appBuilder.UseMiddleware<RequestResponseLoggingMiddleware>(opt.ReqResHandler, logWriter);

            return appBuilder;
        }
    }
}
