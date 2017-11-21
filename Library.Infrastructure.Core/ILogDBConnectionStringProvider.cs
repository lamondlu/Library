using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Core
{
    public interface ILogDBConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
