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

        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            return await _userService.GetUserById(id);
        }
    
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            return await _userService.AddUser(userDTO);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(string id, UpdateUserDTO userDTO)
        {
            return await _userService.UpdateUser(id, userDTO);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}
