using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<GenericCommandResult> HandleAsync(T command);
    }
}
