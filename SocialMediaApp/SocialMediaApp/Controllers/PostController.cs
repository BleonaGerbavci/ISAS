using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _postService;

        public PostController(IPost postService)
        {
            _postService = postService;
        }

        [HttpGet("GetPosts")]
        public async Task<ActionResult<List<PostDTO>>> GetPosts()
        {
            return await _postService.GetPosts();
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<ActionResult<PostDTO>> GetPostById(int id)
        {
            return await _postService.GetPostById(id);
        }

        [HttpPost("AddPost")]
        public async Task<ActionResult> AddPost(PostDTO postDTO)
        {
            return await _postService.AddPost(postDTO);
        }

        [HttpPut("UpdatePost")]
        public async Task<ActionResult> UpdatePost(int id, UpdatePostDTO updatePostDTO)
        {
            return await _postService.UpdatePost(id, updatePostDTO);
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            return await _postService.DeletePost(id);
        }
    }
}
