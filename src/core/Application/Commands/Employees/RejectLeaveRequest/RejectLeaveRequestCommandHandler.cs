using Application.Interfaces;
using MediatR;

namespace Application.Commands.Employees.RejectLeaveRequest;

public class RejectLeaveRequestCommandHandler : IRequestHandler<RejectLeaveRequestCommand, Unit>
{
    private readonly IEmployeeRepository _repository;

    public RejectLeaveRequestCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(RejectLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            throw new Exception("Not Found");

        employee.RejectLeaveRequest(request.LeaveRequestId, request.RejectionReason);

        await _repository.UpdateAsync(employee);

        return Unit.Value;
    }
}
