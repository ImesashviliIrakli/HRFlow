using Application.Interfaces.Messaging;
using Application.Interfaces.MongoDb;
using Domain.Events;

namespace Application.Events.Employee;

public sealed class EmployeeCreatedEventHandler : IDomainEventHandler<EmployeeCreatedEvent>
{
    private readonly IEmployeeNoSqlRepository _employeeMongo;
    public EmployeeCreatedEventHandler(IEmployeeNoSqlRepository employeeMongo)
    {
        _employeeMongo = employeeMongo;
    }

    public async Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _employeeMongo.AddEmployee(notification.employee);
    }
}
