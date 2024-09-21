using Application.Interfaces;
using MediatR;

namespace Application.Commands.LeaveRequests.ApproveLeaveRequest;

public class ApproveLeaveRequestCommandHandler : IRequestHandler<ApproveLeaveRequestCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    public ApproveLeaveRequestCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(ApproveLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId);
        if (employee == null)
            throw new Exception($"Not Found");

        employee.ApproveLeaveRequest(request.LeaveRequestId);

        await _repository.UpdateAsync(employee);

        return Unit.Value;
    }
}
