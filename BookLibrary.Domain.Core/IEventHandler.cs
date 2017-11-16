using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Core
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent evt);

        Task HandleAsync(TEvent evt);
    }
}
