using Application.Commands.LeaveRequests.SubmitLeaveRequest;
using Application.Models.LeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

    [HttpPost]
    public async Task<IActionResult> SubmitLeaveRequest([FromBody] SubmitLeaveRequest submitLeaveRequest)
    {
        var command = new SubmitLeaveRequestCommand(GetCurrentUserId(), submitLeaveRequest.StartDate, submitLeaveRequest.EndDate, submitLeaveRequest.Reason);

        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
