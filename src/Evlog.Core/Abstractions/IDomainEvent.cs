using MediatR;

namespace Evlog.Core.Abstractions
{
    public interface IDomainEvent : INotification
    {

    }

    public interface IDomainEventHandler<T> : INotificationHandler<T>
        where T : IDomainEvent
    {

    }
}
