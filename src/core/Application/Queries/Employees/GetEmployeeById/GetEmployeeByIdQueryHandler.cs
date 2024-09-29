using Application.Interfaces.Messaging;
using Application.Models.Employee;
using AutoMapper;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Queries.Employees.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeDetailsDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    public async Task<Result<EmployeeDetailsDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result.Failure<EmployeeDetailsDto>(DomainErrors.Employee.NotFoundByEmpId(request.EmployeeId));

        var employeeDetailsDto = _mapper.Map<EmployeeDetailsDto>(employee);

        return employeeDetailsDto;
    }
}
