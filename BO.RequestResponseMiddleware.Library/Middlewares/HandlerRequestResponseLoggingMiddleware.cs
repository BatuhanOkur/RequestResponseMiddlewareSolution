using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Middlewares
{
    internal class HandlerRequestResponseLoggingMiddleware : BaseRequestResponseMiddleware
    {
        private readonly Func<RequestResponseContext, Task> reqResHandler;

        public HandlerRequestResponseLoggingMiddleware(RequestDelegate next, Func<RequestResponseContext, Task> reqResHandler)
            :base(next)
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
