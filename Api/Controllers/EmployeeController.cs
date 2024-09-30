using Application.Commands.Employees.DeleteEmployee;
using Application.Commands.Employees.UpdateEmployeeDetails;
using Application.Queries.Employees.GetEmployeeById;
using Application.Queries.Employees.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseController
{
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Query
    [HttpGet("GetEmployees")]
    public async Task<IActionResult> GetEmployees()
    {
        var query = new GetEmployeesQuery();

        var data = await _mediator.Send(query);

        return data.IsSuccess ? Ok(data.Value) : BadRequest(data.Error);
    }

    [HttpGet("GetEmployeeById/{employeeId}")]
    public async Task<IActionResult> GetEmployeeById(Guid employeeId)
    {
        var query = new GetEmployeeByIdQuery(employeeId);

        var data = await _mediator.Send(query);

        return data.IsSuccess ? Ok(data.Value) : BadRequest(data.Error);
    }
    #endregion

    #region Command
    [HttpPut("UpdateEmployeeDetails")]
    public async Task<IActionResult> UpdateEmployeeDetails([FromBody] UpdateEmployeeDetailsCommand updateEmployeeDetailsCommand)
    {
        var data = await _mediator.Send(updateEmployeeDetailsCommand);

        return data.IsSuccess ? Ok(data) : BadRequest(data.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteEmployee/{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId)
    {
        var command = new DeleteEmployeeCommand(employeeId);

        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : BadRequest(data.Error);
    }
    #endregion
}
