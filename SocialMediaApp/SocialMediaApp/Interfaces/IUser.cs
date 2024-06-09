using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;

namespace SocialMediaApp.Interfaces
{
    public interface IUser
    {
        public Task<ActionResult<List<UserDTO>>> GetUsers();
        public Task<ActionResult> AddUser(UserDTO userDTO);
    }
}
