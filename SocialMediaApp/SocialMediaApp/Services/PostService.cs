using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using System.Net.Http;
using System.Security.Policy;

namespace SocialMediaApp.Services
{
    public class PostService : IPost
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PostService> _logger;

        public PostService(DataContext context, IMapper mapper, ILogger<PostService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ActionResult<List<PostDTO>>> GetPosts()
            {
            _logger.LogInformation("Fetching all posts");
            var posts = await _context.Posts.ToListAsync();

            _logger.LogInformation("Fetched {Count} posts", posts.Count);
            return _mapper.Map<List<PostDTO>>(posts);

        }

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

            // Delete related comments
            var postComments = await _context.Comments.Where(c => c.PostID == id).ToListAsync();
            _context.Comments.RemoveRange(postComments);

            _context.Posts.Remove(dbPost);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Post deleted successfully!");
        }
    }
}
