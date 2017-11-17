using System;
using System.Threading.Tasks;
using  Library.Domain.Core;

namespace  Library.Service.Identity.Domain
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