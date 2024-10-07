using Application.Interfaces.Messaging;
using Application.Interfaces.MongoDb;
using Application.Models.Employee;
using AutoMapper;
using Domain.Errors;
using Domain.Shared;

namespace Application.Queries.Employees.GetEmployees;

public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    private readonly IEmployeeNoSqlRepository _employeeMongo;
    private readonly IMapper _mapper;
    public GetEmployeesQueryHandler(IEmployeeNoSqlRepository employeeMongo, IMapper mapper)
    {
        _employeeMongo = employeeMongo;
        _mapper = mapper;
    }

    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeMongo.GetEmployees();

        if (employees is null)
            return Result.Failure<List<EmployeeDto>>(DomainErrors.Employee.NoEmployees);

        var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

        return employeesDto;
    }
}
