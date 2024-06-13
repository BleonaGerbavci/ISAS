using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;

namespace SocialMediaApp.Interfaces
{
    public interface IComment
    {
        Task<ActionResult<List<CommentDTO>>> GetComments();
        Task<ActionResult<CommentDTO>> GetCommentById(int id);
        Task<ActionResult> AddComment(CommentDTO commentDTO);
        Task<ActionResult> UpdateComment(int id, CommentDTO commentDTO);
        Task<ActionResult> DeleteComment(int id);
    }
}
