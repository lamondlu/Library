using Library.Domain.Core;
using System;
using System.Threading.Tasks;

namespace Library.Service.Identity.Domain
{
    public class AdministratorCreatedEventHandler : IEventHandler<AdministratorCreatedEvent>
    {
        public void HandleCore(AdministratorCreatedEvent evt)
        {
        }

        public Task HandleAsync(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }

        public void Handle(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}