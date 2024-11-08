﻿using Application.Interfaces.Messaging;

namespace Application.Commands.LeaveRequests.RejectLeaveRequest;

public class RejectLeaveRequestCommand : ICommand
{
    public Guid EmployeeId { get; }
    public Guid LeaveRequestId { get; }
    public string RejectionReason { get; }

    public RejectLeaveRequestCommand(Guid employeeId, Guid leaveRequestId, string rejectionReason)
    {
        EmployeeId = employeeId;
        LeaveRequestId = leaveRequestId;
        RejectionReason = rejectionReason;
    }
}
