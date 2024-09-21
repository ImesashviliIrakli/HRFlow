using Application.Interfaces;
using MediatR;

namespace Application.Commands.LeaveRequests.SubmitLeaveRequest;

public class SubmitLeaveRequestCommandHandler : IRequestHandler<SubmitLeaveRequestCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    public SubmitLeaveRequestCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(SubmitLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            throw new Exception("Not Found");

        employee.AddLeaveRequest(request.StartDate, request.EndDate, request.Reason);

        await _repository.UpdateAsync(employee);

        return Unit.Value;
    }
}
