using Application.Interfaces.Messaging;
using Application.Models.Employee;
using AutoMapper;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Queries.Employees.GetEmployees;

public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetEmployees();

        if (employees is null)
            return Result.Failure<List<EmployeeDto>>(DomainErrors.Employee.NoEmployees);

        var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

        return employeesDto;
    }
}
