using Application.Commands.LeaveRequests.ApproveLeaveRequest;
using Application.Commands.LeaveRequests.RejectLeaveRequest;
using Application.Commands.LeaveRequests.SubmitLeaveRequest;
using Application.Models.LeaveRequest;
using Application.Queries.LeaveRequests.GetEmployeLeaveRequests;
using Application.Queries.LeaveRequests.GetLeaveRequestById;
using Application.Queries.LeaveRequests.GetLeaveRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaveController : BaseController
{
    private readonly IMediator _mediator;
    public LeaveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Query
    [HttpGet("GetLeaveRequests")]
    public async Task<IActionResult> GetLeaveRequests()
    {
        var query = new GetLeaveRequestsQuery();

        var data = await _mediator.Send(query);

        return data.IsSuccess ? Ok(data.Value) : NotFound(data.Error);
    }

    [HttpGet("GetLeaveRequestById/{leaveRequestId}")]
    public async Task<IActionResult> GetLeaveRequestById(Guid leaveRequestId)
    {
        var query = new GetLeaveRequestByIdQuery(leaveRequestId);

        var data = await _mediator.Send(query);

        return data.IsSuccess ? Ok(data.Value) : NotFound(data.Error);
    }

    [HttpGet("GetEmployeeLeaveRequests/{employeeId}")]
    public async Task<IActionResult> GetEmployeeLeaveRequests(Guid employeeId)
    {
        var query = new GetEmployeLeaveRequestsQuery(employeeId);

        var data = await _mediator.Send(query);

        return data.IsSuccess ? Ok(data.Value) : NotFound(data.Error);
    }
    #endregion

    #region Command
    [HttpPost("SubmitLeaveRequest")]
    public async Task<IActionResult> SubmitLeaveRequest([FromBody] SubmitLeaveRequest submitLeaveRequest)
    {
        var command = new SubmitLeaveRequestCommand(GetCurrentUserId(), submitLeaveRequest.StartDate, submitLeaveRequest.EndDate, submitLeaveRequest.Reason);

        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("RejectLeaveRequest")]
    public async Task<IActionResult> RejectLeaveRequest([FromBody] RejectLeaveRequestCommand command)
    {
        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("ApproveLeaveRequest")]
    public async Task<IActionResult> ApproveLeaveRequest([FromBody] ApproveLeaveRequestCommand command)
    {
        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }
    #endregion
}
