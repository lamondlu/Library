using System;
using System.Collections.Generic;
using System.Text;
using Library.Infrastructure.Operation.Core.Models;

namespace Library.Infrastructure.Operation.Core
{
    public abstract class BaseServiceDiscovery : IServiceDiscovery
    {
        public abstract void RegisterService(Service service);
    }
}
