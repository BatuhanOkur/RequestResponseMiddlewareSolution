using BO.RequestResponseMiddleware.Library.Interfaces;
using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Middlewares
{
    public class RequestResponseLoggingMiddleware: BaseRequestResponseMiddleware
    {
        
        private readonly ILogWriter logWriter;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogWriter logWriter)
            :base(next, logWriter)
        {
            this.logWriter = logWriter;
        }

        public async Task Invoke(HttpContext context)
        {
           var reqResContext = await BaseMiddlewareInvoke(context);
        }        
    }
}
