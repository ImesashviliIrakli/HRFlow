﻿using MediatR;

namespace Application.Commands.Employees.ApproveLeaveRequest;

public class ApproveLeaveRequestCommand : IRequest<Unit>
{
    public Guid EmployeeId { get; }
    public Guid LeaveRequestId { get; }

    public ApproveLeaveRequestCommand(Guid employeeId, Guid leaveRequestId)
    {
        EmployeeId = employeeId;
        LeaveRequestId = leaveRequestId;
    }
}
