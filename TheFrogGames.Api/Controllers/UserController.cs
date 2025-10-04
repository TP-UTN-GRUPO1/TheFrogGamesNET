using Contract.User.Request;
using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Service;
using TheFrogGames.Contracts.User.Request;
using TheFrogGames.Contracts.User.Response;

namespace TheFrogGames.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetUserById(id);

        return Ok(user);
    }

    [HttpPost]

    public ActionResult CreateUser([FromBody] CreateUserRequest user)
    {
        var isCreated = _userService.CreateUser(user);
        if (!isCreated)
        {
            return BadRequest("No se pudo crear el usuario");
        }
        return Ok("Usuario creado");
    }

    [HttpGet]
    public ActionResult<List<UserResponse>> GetAllUsers()
    {
        var usersList = _userService.GetAllUsers();
        if (!usersList.Any())
        {
            return NotFound();
        }
        return Ok(usersList);
    }
    [HttpPatch("{id}/status")]
    public ActionResult UpdateUserStatus([FromRoute] int id, [FromBody] UserStatusRequest user)
    {
        user.Id = id;
        var isActive = _userService.UpdateUserStatus(user);
        if (!isActive)
        {
            return Conflict("No se puede dar de baja al usuario");
        }
        return NoContent();
    }
}
