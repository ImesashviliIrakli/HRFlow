using Domain.Entities;

namespace Domain.Events;

public sealed record DeleteEmployeeEvent(Guid id, Employee employee) : DomainEvent(id);

public sealed record EmployeeCreatedEvent(Guid id, Employee employee) : DomainEvent(id);

public sealed record EmployeeDetailsUpdatedEvent(Guid id, Employee employee) : DomainEvent(id);

public sealed record EmployeePositionChangedEvent(Guid id, Employee employee) : DomainEvent(id);