using BookingLibrary.Domain.Core.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.Commands
{
    public class CommandBase<T> : ICommand where T : CommandExecuteResult, new()
    {
        public T ExecuteResult { get; protected set; }

        public CommandBase()
        {
            this.ExecuteResult = new T();
        }

        public void ExecuteSuccess()
        {
            this.ExecuteResult.ExecuteSuccess();
        }

        public void ExecuteSuccess(Guid id)
        {
            this.ExecuteResult.ExecuteSuccess(id);
        }

        public void ExecuteFail(BusinessOperationResult error)
        {
            this.ExecuteResult.ExecuteFail(error);
        }

        public void ExecuteFail(IEnumerable<BusinessOperationResult> errors)
        {
            this.ExecuteResult.ExecuteFail(errors);
        }
    }

}
