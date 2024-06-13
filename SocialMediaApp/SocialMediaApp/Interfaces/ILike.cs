using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;

namespace SocialMediaApp.Interfaces
{
    public interface ILike
    {
        Task<ActionResult<List<LikeDTO>>> GetLikes();
        Task<ActionResult<LikeDTO>> GetLikeById(int id);
        Task<ActionResult> AddLike(LikeDTO likeDTO);
        Task<ActionResult> UpdateLike(int id, UpdateLikeDTO likeDTO);
        Task<ActionResult> DeleteLike(int id);
    }
}
