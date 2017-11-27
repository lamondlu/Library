using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Core
{
    public interface ILogDBConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
