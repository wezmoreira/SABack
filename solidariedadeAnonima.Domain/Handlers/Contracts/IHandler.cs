using MediatR;
using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Contracts;
using solidariedadeAnonima.Domain.Shared;

namespace solidariedadeAnonima.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<GenericCommandResult> HandleAsync(T command);
    }


    public interface IHandler<TCommand, TResponse>
        : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}
