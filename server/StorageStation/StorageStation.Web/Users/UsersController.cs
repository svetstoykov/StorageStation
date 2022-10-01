using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageStation.Application.Users.Commands;
using StorageStation.Web.Common.Controllers;
using StorageStation.Web.Users.Models;

namespace StorageStation.Web.Users;

[AllowAnonymous]
public class UsersController : BaseApiController
{
    public UsersController(IMediator mediator, IMapper mapper) 
        : base(mediator, mapper)
    {
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginApiModel request)
        => this.HandleResult(await this.Mediator.Send(
            new Login.Command(request.Username, request.Password)));

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterApiModel request)
        => this.HandleResult(await this.Mediator.Send(
            new Register.Command(request.FirstName, request.Username, request.Password, request.Email, request.HouseholdId)));
}