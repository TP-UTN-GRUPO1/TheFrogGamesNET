using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Service;

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
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        return Ok(user);
    }

}
