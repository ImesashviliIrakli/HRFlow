using Application.Interfaces.Messaging;
using Application.Interfaces.MongoDb;
using Application.Models.Employee;
using AutoMapper;
using Domain.Errors;
using Domain.Shared;

namespace Application.Queries.Employees.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeDetailsDto>
{
    private readonly IEmployeeNoSqlRepository _employeeMongo;
    private readonly IMapper _mapper;
    public GetEmployeeByIdQueryHandler(IEmployeeNoSqlRepository employeeMongo, IMapper mapper)
    {
        _employeeMongo = employeeMongo;
        _mapper = mapper;
    }
    public async Task<Result<EmployeeDetailsDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeMongo.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result.Failure<EmployeeDetailsDto>(DomainErrors.Employee.NotFoundByEmpId(request.EmployeeId));

        var employeeDetailsDto = _mapper.Map<EmployeeDetailsDto>(employee);

        return employeeDetailsDto;
    }
}
