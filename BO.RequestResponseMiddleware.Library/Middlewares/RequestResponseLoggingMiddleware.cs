using BO.RequestResponseMiddleware.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Middlewares
{
    public class RequestResponseLoggingMiddleware: BaseRequestResponseMiddleware
    {
        
        

        public RequestResponseLoggingMiddleware(RequestDelegate next, RequestResponseOptions reqResOptions)
            :base(next)
        {
            
        }

        public async Task Invoke(HttpContext context)
        {
            await BaseMiddlewareInvoke(context);            
        }        
    }
}
