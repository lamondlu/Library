using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class AdministratorCreatedEventHandler : IEventHandler<AdministratorCreatedEvent>
    {
        void IEventHandler<AdministratorCreatedEvent>.Handle(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }

        Task IEventHandler<AdministratorCreatedEvent>.HandleAsync(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }

        void IEventHandler<AdministratorCreatedEvent>.Rollback(AdministratorCreatedEvent evt, AggregateRoot previousVersion)
        {
            throw new NotImplementedException();
        }
    }
}