using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using SocialMediaApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

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


        public async Task<ActionResult> AddUser(UserDTO userDTO)
        {
            if (userDTO == null)
                return new BadRequestObjectResult("User can not be null!!");
            var mappedUser = _mapper.Map<User>(userDTO);
            await _context.Users.AddAsync(mappedUser);
            await _context.SaveChangesAsync();
            return new OkObjectResult("User added successfully!");
        }
    }
}
