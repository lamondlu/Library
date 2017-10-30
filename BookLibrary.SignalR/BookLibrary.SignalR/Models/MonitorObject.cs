using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibrary.SignalR.Models
{
    public class MonitoredCommand
    {
        public Guid CommandUniqueId { get; set; }

        public List<string> EventNames { get; set; }
    }

}