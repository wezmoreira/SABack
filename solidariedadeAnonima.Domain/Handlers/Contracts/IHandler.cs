using solidariedadeAnonima.Domain.Commands;
using solidariedadeAnonima.Domain.Commands.Contracts;

namespace solidariedadeAnonima.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<GenericCommandResult> HandleAsync(T command);
    }

    public interface IHandler<TCommand, CancelationToken> where TCommand : ICommand
    {
        Task<GenericCommandResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
