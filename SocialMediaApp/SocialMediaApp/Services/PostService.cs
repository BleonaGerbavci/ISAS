using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using System.Net.Http;

namespace SocialMediaApp.Services
{
    public class PostService : IPost
    { 
    
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public PostService(DataContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<List<PostDTO>>> GetPosts() =>
            _mapper.Map<List<PostDTO>>(await _context.Posts.ToListAsync());

        public async Task<ActionResult<PostDTO>> GetPostById(int id)
        {
            var mappedPost = _mapper.Map<PostDTO>(await _context.Posts.FindAsync(id));
            return mappedPost == null
                ? new NotFoundObjectResult("Post doesn't exist!!")
                : new OkObjectResult(mappedPost);
        }
        public async Task<ActionResult> AddPost(PostDTO postDTO)
        {
            if (postDTO == null)
                return new BadRequestObjectResult("Post can not be null!!");
            var mappedPost = _mapper.Map<Post>(postDTO);
            await _context.Posts.AddAsync(mappedPost);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Post added successfully!");
        }

        public async Task<ActionResult> UpdatePost(int id, UpdatePostDTO updatePostDTO)
        {
            if (updatePostDTO == null)
                return new BadRequestObjectResult("Post can not be null!!");

            var dbPost = await _context.Posts.FindAsync(id);
            if (dbPost == null)
                return new NotFoundObjectResult("Post doesn't exist!!");

            dbPost.Content = updatePostDTO.Content ?? dbPost.Content;
            dbPost.MediaType = updatePostDTO.MediaType ?? dbPost.MediaType;
            dbPost.MediaURL = updatePostDTO.MediaURL ?? dbPost.MediaURL;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Post updated successfully!");
        }

        public async Task<ActionResult> DeletePost(int id)
        {
            var dbPost = await _context.Posts.FindAsync(id);
            if (dbPost == null)
                return new NotFoundObjectResult("Post doesn't exist!!");

            _context.Posts.Remove(dbPost);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Post deleted successfully!");
        }
    }
}
