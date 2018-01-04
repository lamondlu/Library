using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Operation.Core.Models
{
    public class Service
    {
        public string ServiceUniqueId { get; set; }

        public string ServiceName { get; set; }

        public string Tag { get; set; }

        public string Address { get; set; }

        public string Port { get; set; }
    }
}
