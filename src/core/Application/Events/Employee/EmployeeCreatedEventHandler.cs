using Application.Interfaces.Messaging;
using Domain.Events;

namespace Application.Events.Employee;

public sealed class EmployeeCreatedEventHandler : IDomainEventHandler<EmployeeCreatedEvent>
{
    public EmployeeCreatedEventHandler()
    {
        
    }

    public Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
