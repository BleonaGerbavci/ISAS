using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Data;
using SocialMediaApp.DTOs;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;


namespace SocialMediaApp.Services
{
    public class CommentService : IComment
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentService(DataContext context, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<List<CommentDTO>>> GetComments()
        {
            var comments = await _context.Comments.ToListAsync();
            return _mapper.Map<List<CommentDTO>>(comments);
        }

        public async Task<ActionResult<CommentDTO>> GetCommentById(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
                return new NotFoundObjectResult("Comment doesn't exist!");

            var commentDTO = _mapper.Map<CommentDTO>(comment);
            return new OkObjectResult(commentDTO);
        }

        public async Task<ActionResult> AddComment(CommentDTO commentDTO)
        {
            if (commentDTO == null)
                return new BadRequestObjectResult("Comment can not be null!");

            var comment = _mapper.Map<Comment>(commentDTO);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Comment added successfully!");
        }

        public async Task<ActionResult> UpdateComment(int id, CommentDTO commentDTO)
        {
            if (commentDTO == null)
                return new BadRequestObjectResult("Comment can not be null!");

            var dbComment = await _context.Comments.FindAsync(id);
            if (dbComment == null)
                return new NotFoundObjectResult("Comment doesn't exist!");

            dbComment.Content = commentDTO.Content;
            dbComment.Timestamp = commentDTO.Timestamp;

            await _context.SaveChangesAsync();
            return new OkObjectResult("Comment updated successfully!");
        }

        public async Task<ActionResult> DeleteComment(int id)
        {
            var dbComment = await _context.Comments.FindAsync(id);
            if (dbComment == null)
                return new NotFoundObjectResult("Comment doesn't exist!");

            _context.Comments.Remove(dbComment);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Comment deleted successfully!");
        }
    }
}
