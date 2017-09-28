using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public class AdministratorCreatedEventHandler : IEventHandler<AdministratorCreatedEvent>
    {
        public void Handle(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }

        public Task HandleAsync(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }

        public void Rollback(AdministratorCreatedEvent evt, AggregateRoot previousVersion)
        {
            throw new NotImplementedException();
        }
    }
}