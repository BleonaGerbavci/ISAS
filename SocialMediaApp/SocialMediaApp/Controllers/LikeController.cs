using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILike _likeService;

        public LikeController(ILike likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("GetLikes")]
        public async Task<ActionResult<List<LikeDTO>>> GetLikes()
        {
            return await _likeService.GetLikes();
        }

        [HttpGet("GetLikeById/{id}")]
        public async Task<ActionResult<LikeDTO>> GetLikeById(int id)
        {
            return await _likeService.GetLikeById(id);
        }

        [HttpPost("AddLike")]
        public async Task<ActionResult> AddLike(LikeDTO likeDTO)
        {
            return await _likeService.AddLike(likeDTO);
        }

        [HttpPut("UpdateLike/{id}")]
        public async Task<ActionResult> UpdateLike(int id, UpdateLikeDTO updateLikeDTO)
        {
            return await _likeService.UpdateLike(id, updateLikeDTO);
        }

        [HttpDelete("DeleteLike/{id}")]
        public async Task<ActionResult> DeleteLike(int id)
        {
            return await _likeService.DeleteLike(id);
        }
    }
}
