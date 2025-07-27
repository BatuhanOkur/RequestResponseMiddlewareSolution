using BO.RequestResponseMiddleware.Library.Interfaces;
using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Middlewares
{
    public class HandlerRequestResponseLoggingMiddleware : BaseRequestResponseMiddleware
    {
        private readonly Func<RequestResponseContext, Task> reqResHandler;

        public HandlerRequestResponseLoggingMiddleware(RequestDelegate next, Func<RequestResponseContext, Task> reqResHandler, ILogWriter logWriter)
            :base(next, logWriter)
        {
            this.reqResHandler = reqResHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            var reqResContext = await BaseMiddlewareInvoke(context);
            await reqResHandler.Invoke(reqResContext);
        }
    }
}
