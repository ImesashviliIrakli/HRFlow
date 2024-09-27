using Application.Interfaces;
using MediatR;

namespace Application.Commands.LeaveRequests.SubmitLeaveRequest;

public class SubmitLeaveRequestCommandHandler : IRequestHandler<SubmitLeaveRequestCommand, Unit>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILeaveRepository _leaveRepository;
    public SubmitLeaveRequestCommandHandler(IEmployeeRepository employeeRepository, ILeaveRepository leaveRepository)
    {
        _employeeRepository = employeeRepository;
        _leaveRepository = leaveRepository;
    }
    public async Task<Unit> Handle(SubmitLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByUserIdAsync(request.UserId);

        if (employee == null)
            throw new Exception("Not Found");

        var leaveRequest = employee.AddLeaveRequest(request.StartDate, request.EndDate, request.Reason);

        await _leaveRepository.AddAsync(leaveRequest);

        return Unit.Value;
    }
}
