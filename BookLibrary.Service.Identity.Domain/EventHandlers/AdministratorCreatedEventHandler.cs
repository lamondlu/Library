using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;

namespace BookLibrary.Service.Identity.Domain
{
    public class AdministratorCreatedEventHandler : IEventHandler<AdministratorCreatedEvent>
    {
        public void Handle(AdministratorCreatedEvent evt)
        {
            
        }

        public Task HandleAsync(AdministratorCreatedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}