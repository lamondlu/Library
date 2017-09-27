using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.EventStorage
{
    public class BaseEventStorageModel
    {
        public Guid Id { get; set; }

        public int Version { get; set; }
    }
}
