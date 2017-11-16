using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Core.Commands
{
    public interface ICommand
    {
        string CommandKey { get; }
    }
}
