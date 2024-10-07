using Application.Interfaces.Messaging;
using Application.Interfaces.MongoDb;
using Application.Models.NoSqlDocuments;
using AutoMapper;
using Domain.Events;

namespace Application.Events.Employee;

public class EmployeeDetailsUpdatedEventHandler : IDomainEventHandler<EmployeeDetailsUpdatedEvent>
{
    private readonly IEmployeeNoSqlRepository _employeeMongo;
    private readonly IMapper _mapper;
    public EmployeeDetailsUpdatedEventHandler(IEmployeeNoSqlRepository employeeMongo, IMapper mapper)
    {
        _employeeMongo = employeeMongo;
        _mapper = mapper;
    }
    public async Task Handle(EmployeeDetailsUpdatedEvent notification, CancellationToken cancellationToken)
    {
        var employeeDocument = _mapper.Map<EmployeeDocument>(notification.employee);

        await _employeeMongo.UpdateEmployeeDetailsAsync(employeeDocument);
    }
}
