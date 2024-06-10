using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;

namespace SocialMediaApp.Interfaces
{
    public interface IUser
    {
        public Task<ActionResult<List<UserDTO>>> GetUsers();
        public Task<ActionResult<UserDTO>> GetUserById(string id);
        public Task<ActionResult> AddUser(UserDTO userDTO);
        public Task<ActionResult> UpdateUser(string id, UpdateUserDTO updateUserDTO);
        public Task<ActionResult> DeleteUser(string id);
    }
}
