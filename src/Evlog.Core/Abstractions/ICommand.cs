using MediatR;

namespace Evlog.Core.Abstractions
{
    interface ICommand : IRequest
    {

    }

    interface IAsyncCommandHandler<T> : IRequestHandler<T>
        where T : ICommand
    {

    }
}
