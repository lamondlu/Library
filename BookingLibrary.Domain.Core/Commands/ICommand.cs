using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core.Errors;

namespace BookingLibrary.Domain.Core.Commands
{
    public interface ICommand
    {
        string CommandKey { get; }

        void ExecuteSuccess();

        void ExecuteSuccess(Guid id);

        void ExecuteFail(BusinessOperationResult error);

        void ExecuteFail(IEnumerable<BusinessOperationResult> errors);
    }
}
