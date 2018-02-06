using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.Commands;
using Library.Service.Identity.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Identity.Domain.CommandHandlers
{
    public class CreateUserCommandHandler : BaseIdentityCommandHandler<CreateUserCommand>
    {
        public CreateUserCommandHandler(IDomainRepository domainRepository, IIdentityReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
        {
        }

        public override void ExecuteCore(CreateUserCommand command)
        {
            var user = new User(new Library.Domain.Core.PersonName(command.FirstName, command.MiddleName, command.LastName), new UserPrincipal(UserRole.User, command.UserName, command.Password));

            _domainRepository.Save(user, -1, command.CommandUniqueId);
        }
    }
}
