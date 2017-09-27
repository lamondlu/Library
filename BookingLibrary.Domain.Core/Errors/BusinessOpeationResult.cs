using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Domain.Core.Errors
{
    public class BusinessOperationResult
    {
        private static Dictionary<int, string> ErrorMessages = new Dictionary<int, string>()
        {
        };

        public int ErrorCode
        {
            get;
            private set;
        }

        public string Message
        {
            get;
            private set;
        }

        public BusinessOperationResult(int errorCode)
        {
            this.ErrorCode = errorCode;

            if (ErrorMessages.ContainsKey(errorCode))
            {
                this.Message = ErrorMessages[errorCode];
            }
        }

        public BusinessOperationResult(int errorCode, string message)
            : this(errorCode)
        {
            this.Message = message;
        }
    }

}
