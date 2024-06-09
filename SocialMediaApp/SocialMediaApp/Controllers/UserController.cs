using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            return await _userService.AddUser(userDTO);
        }
    }
}
