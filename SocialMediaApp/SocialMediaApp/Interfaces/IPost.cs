using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.DTOs;

namespace SocialMediaApp.Interfaces
{
    public interface IPost
    {
        Task<ActionResult<List<PostDTO>>> GetPosts();
        Task<ActionResult<PostDTO>> GetPostById(int id);
        Task<ActionResult> AddPost(PostDTO postDTO);
        Task<ActionResult> UpdatePost(int id, UpdatePostDTO updatePostDTO);
        Task<ActionResult> DeletePost(int id);
    }
}
