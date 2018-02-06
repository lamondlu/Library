using Library.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Identity.Domain.Commands
{
    public class CreateUserCommand : CommonCommand
    {
        private static string AddUserCommandKey = "Command_AddUser";

        public CreateUserCommand() : base(AddUserCommandKey)
        {

        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
