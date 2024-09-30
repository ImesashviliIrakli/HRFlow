using MediatR;

namespace Domain.Primitives;

public abstract class DomainEvent : INotification
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;
}
