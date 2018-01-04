using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Operation.Consul
{
    public interface IConsulAPIUrlProvider
    {
        string Url { get; }
    }
}
