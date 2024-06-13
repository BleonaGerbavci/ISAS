using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _commentService;

        public CommentController(IComment commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetComments")]
        public async Task<ActionResult<List<CommentDTO>>> GetComments()
        {
            return await _commentService.GetComments();
        }

        [HttpGet("GetCommentById/{id}")]
        public async Task<ActionResult<CommentDTO>> GetCommentById(int id)
        {
            return await _commentService.GetCommentById(id);
        }

        [HttpPost("AddComment")]
        public async Task<ActionResult> AddComment(CommentDTO commentDTO)
        {
            return await _commentService.AddComment(commentDTO);
        }

        [HttpPut("UpdateComment/{id}")]
        public async Task<ActionResult> UpdateComment(int id, CommentDTO commentDTO)
        {
            return await _commentService.UpdateComment(id, commentDTO);
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            return await _commentService.DeleteComment(id);
        }
    }
}
