using BO.RequestResponseMiddleware.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.RequestResponseMiddleware.Library.Interfaces
{
    public interface ILogWriter
    {
        Task Write(RequestResponseContext context);
    }
}
