using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected ResponseModel _response;

    public BaseController()
    {
        _response = new ResponseModel(Status.Success, "Success");
    }

    // Get the current user ID from the claims
    protected string GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId is null)
            throw new Exception("Not Found");

        return userId;
    }

    // Get the current user's email from the claims
    protected string GetCurrentUserEmail()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        if (email is null)
            throw new Exception("NotFound");

        return email;
    }

    // Method to set the response
    protected IActionResult CreateResponse(object? data = null)
    {
        _response.Result = data;
        return Ok(_response);
    }
}
