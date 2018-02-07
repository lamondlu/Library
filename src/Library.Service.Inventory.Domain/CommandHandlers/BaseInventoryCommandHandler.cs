using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public abstract class BaseInventoryCommandHandler<T> : BaseCommandHandler<T> where T : CommonCommand
    {
        protected IDomainRepository _domainRepository = null;
        protected IInventoryReportDataAccessor _dataAccessor = null;

        public BaseInventoryCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(tracker, logger)
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