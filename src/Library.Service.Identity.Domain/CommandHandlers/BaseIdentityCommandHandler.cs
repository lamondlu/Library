using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Identity.Domain.CommandHandlers
{
    public abstract class BaseIdentityCommandHandler<T> : BaseCommandHandler<T> where T : CommonCommand
    {
        protected IDomainRepository _domainRepository = null;
        protected IIdentityReportDataAccessor _dataAccessor = null;

        public BaseIdentityCommandHandler(IDomainRepository domainRepository, IIdentityReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(tracker, logger)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
        }

        public override void Dispose()
        {
            _domainRepository = null;
            _dataAccessor = null;

            base.Dispose();
        }
    }
}
