using Application.Commands.Employees.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        var response = await _mediator.Send(createEmployeeCommand);
        return Ok(response);
    }
}
