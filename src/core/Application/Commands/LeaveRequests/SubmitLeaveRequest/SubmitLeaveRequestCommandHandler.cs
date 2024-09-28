using Application.Interfaces.Messaging;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Commands.LeaveRequests.SubmitLeaveRequest;

public class SubmitLeaveRequestCommandHandler : ICommandHandler<SubmitLeaveRequestCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILeaveRepository _leaveRepository;
    private readonly IUnitOfWork _unitOfWork;
    public SubmitLeaveRequestCommandHandler(
        IEmployeeRepository employeeRepository,
        ILeaveRepository leaveRepository,
        IUnitOfWork unitOfWork
        )
    {
        _employeeRepository = employeeRepository;
        _leaveRepository = leaveRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(SubmitLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByUserIdAsync(request.UserId);

        if (employee == null)
            return Result.Failure(DomainErrors.Employee.NotFound(request.UserId));

        var leaveRequest = employee.AddLeaveRequest(request.StartDate, request.EndDate, request.Reason);

        await _leaveRepository.AddAsync(leaveRequest);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}
