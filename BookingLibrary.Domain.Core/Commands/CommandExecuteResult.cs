using BookingLibrary.Domain.Core.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.Commands
{
    public class CommandExecuteResult
    {
        private List<BusinessOperationResult> executeErrors;

        public bool Success { get; private set; }

        public Guid DomainModelId { get; private set; }

        public IEnumerable<BusinessOperationResult> Errors
        {
            get
            {
                return executeErrors.AsEnumerable();
            }
        }

        public CommandExecuteResult()
        {
            this.executeErrors = new List<BusinessOperationResult>();
        }

        public void ExecuteSuccess()
        {
            this.Success = true;
        }

        public void ExecuteSuccess(Guid id)
        {
            ExecuteSuccess();

            this.DomainModelId = id;
        }

        public void ExecuteFail(BusinessOperationResult error)
        {
            this.Success = false;

            AddError(error);
        }

        public void ExecuteFail(IEnumerable<BusinessOperationResult> errors)
        {
            this.Success = false;

            AddErrors(errors);
        }

        public void AddError(BusinessOperationResult error)
        {
            this.executeErrors.Add(error);
        }

        public void RemoveError(BusinessOperationResult error)
        {
            this.executeErrors.Remove(error);
        }

        public void AddErrors(IEnumerable<BusinessOperationResult> errors)
        {
            this.executeErrors.AddRange(errors);
        }
    }
}
