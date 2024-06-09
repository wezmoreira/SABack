using Flunt.Validations;
using MediatR;
using solidariedadeAnonima.Domain.Shared;

namespace solidariedadeAnonima.Domain.Commands.Contracts { 

    public interface ICommand : IValidatable
    {
    }

    public interface ICommand<TResponse> : IValidatable, IRequest<Result<TResponse>>
    {
     
    } 
}

