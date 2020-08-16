using MediatR;

namespace Evlog.Core.Abstractions
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommandHandler<T> : IRequestHandler<T>
        where T : ICommand
    {

    }
}
