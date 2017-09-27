using BookingLibrary.Domain.Core.EventStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core
{
    public interface IOriginator
    {
        BaseEventStorageModel GetEventModel();

        void SetEventModel(BaseEventStorageModel eventModel);
    }
}
