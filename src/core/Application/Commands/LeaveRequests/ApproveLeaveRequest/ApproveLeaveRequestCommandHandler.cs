using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using MediatR;

namespace Application.Commands.LeaveRequests.ApproveLeaveRequest;

public class ApproveLeaveRequestCommandHandler : IRequestHandler<ApproveLeaveRequestCommand, Result>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ApproveLeaveRequestCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ApproveLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            return Result.Failure(DomainErrors.Employee.NotFound(request.EmployeeId.ToString()));

        employee.ApproveLeaveRequest(request.LeaveRequestId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
