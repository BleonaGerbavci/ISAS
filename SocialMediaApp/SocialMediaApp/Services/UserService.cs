using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using SocialMediaApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace SocialMediaApp.Services
{
    public class UserService : IUser
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(DataContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<List<UserDTO>>> GetUsers() =>
            _mapper.Map<List<UserDTO>>(await _context.Users.ToListAsync());

        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var mappedUser = _mapper.Map<UserDTO>(await _context.Users.FindAsync(id));
            return mappedUser == null
                ? new NotFoundObjectResult("User doesn't exist!!")
                : new OkObjectResult(mappedUser);
        }
        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return new BadRequestObjectResult("User can not be null!!");
            var mappedUser = _mapper.Map<User>(userDTO);
            await _context.Users.AddAsync(mappedUser);
            await _context.SaveChangesAsync();
            return new OkObjectResult("User added successfully!");
        }

        public async Task<ActionResult> UpdateUser(string id, UpdateUserDTO updateUserDTO)
        {
            if (updateUserDTO == null)
                return new BadRequestObjectResult("User can not be null!!");

            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return new NotFoundObjectResult("User doesn't exist!!");
 
            dbUser.Name = updateUserDTO.Name ?? dbUser.Name;
            dbUser.Email = updateUserDTO.Email ?? dbUser.Email;
            dbUser.UserName = updateUserDTO.Username ?? dbUser.UserName;
            dbUser.Bio = updateUserDTO.Bio ?? dbUser.Bio;
            dbUser.ProfilePicture = updateUserDTO.ProfilePicture ?? dbUser.ProfilePicture;

            await _context.SaveChangesAsync();

            return new OkObjectResult("User updated successfully!");
        }

        public async Task<ActionResult> DeleteUser(string id)
        {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return new NotFoundObjectResult("User doesn't exist!!");


            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
            return new OkObjectResult("User deleted successfully!");
        }
    }
}
