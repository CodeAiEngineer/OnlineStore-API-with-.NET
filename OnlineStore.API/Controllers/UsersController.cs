using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Abstract;
using OnlineStore.Entities;
using System;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                var createdUser = _userService.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authData = _userService.Login(loginRequest);
            if (authData == null)
            {
                return Unauthorized();
            }
            return Ok(authData);
        }


        // Other actions...
    }

}
