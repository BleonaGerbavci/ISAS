using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;

namespace SocialMediaApp.Services
{
    public class LikeService : ILike 
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LikeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;    
        }

        public async Task<ActionResult<List<LikeDTO>>> GetLikes()
        {
            var likes = await _context.Likes.ToListAsync();
            return _mapper.Map<List<LikeDTO>>(likes);
        }

        public async Task<ActionResult<LikeDTO>> GetLikeById(int id)
        {
            var like = await _context.Likes.FindAsync(id);
            if (like == null)
                return new NotFoundObjectResult("Like doesn't exist!");

            var likeDTO = _mapper.Map<LikeDTO>(like);
            return new OkObjectResult(likeDTO);
        }

        public async Task<ActionResult> AddLike(LikeDTO likeDTO)
        {
            if (likeDTO == null)
                return new BadRequestObjectResult("Like cannot be null!");

            var like = _mapper.Map<Like>(likeDTO);
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Like added successfully!");
        }

        public async Task<ActionResult> UpdateLike(int id, UpdateLikeDTO likeDTO)
        {
            if (likeDTO == null)
                return new BadRequestObjectResult("Like cannot be null!");

            var dbLike = await _context.Likes.FindAsync(id);
            if (dbLike == null)
                return new NotFoundObjectResult("Like doesn't exist!");

            dbLike.PostID = likeDTO.PostID;
            dbLike.CommentID = likeDTO.CommentID;
            dbLike.UserID = likeDTO.UserID;
            dbLike.Timestamp = likeDTO.Timestamp;

            await _context.SaveChangesAsync();
            return new OkObjectResult("Like updated successfully!");
        }

        public async Task<ActionResult> DeleteLike(int id)
        {
            var dbLike = await _context.Likes.FindAsync(id);
            if (dbLike == null)
                return new NotFoundObjectResult("Like doesn't exist!");

            _context.Likes.Remove(dbLike);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Like deleted successfully!");
        }
    }
}
