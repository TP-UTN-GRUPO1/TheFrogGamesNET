using Contract.User.Request;
using Microsoft.AspNetCore.Mvc;
using TheFrogGames.Application.Services;
using TheFrogGames.Contracts.User.Request;

namespace TheFrogGames.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequest request)
        {
            var response = _userService.CreateUser(request);
            if (response == null) return BadRequest("No se pudo crear usuario");
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            var response = _userService.UpdateUser(id,request);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _userService.DeleteUser(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

