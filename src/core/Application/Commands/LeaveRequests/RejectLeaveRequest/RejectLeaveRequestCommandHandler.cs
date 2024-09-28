using Application.Interfaces.Messaging;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Commands.LeaveRequests.RejectLeaveRequest;

public class RejectLeaveRequestCommandHandler : ICommandHandler<RejectLeaveRequestCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RejectLeaveRequestCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(RejectLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            return Result.Failure(DomainErrors.Employee.NotFound(request.EmployeeId.ToString()));

        employee.RejectLeaveRequest(request.LeaveRequestId, request.RejectionReason);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
