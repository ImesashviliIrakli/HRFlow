using Application.Commands.Auth;
using Application.Commands.Employees.CreateEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        var data = await _mediator.Send(loginCommand);

        return data.IsSuccess
               ? Ok(data.Value)
               : NotFound(data.Error);
    }

    [HttpPost("RegisterEmployee")]
    public async Task<IActionResult> RegisterEmployee([FromBody] CreateEmployeeCommand createEmployeeCommand)
    {
        var data = await _mediator.Send(createEmployeeCommand);

        return data.IsSuccess
               ? Ok(data.Value)
               : NotFound(data.Error);
    }
}
