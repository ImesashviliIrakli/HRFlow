using Domain.Primitives;
using MediatR;

namespace Application.Interfaces.Messaging;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
{
}