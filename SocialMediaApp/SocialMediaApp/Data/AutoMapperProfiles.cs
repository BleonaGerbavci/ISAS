﻿using AutoMapper;
using SocialMediaApp.DTOs;
using SocialMediaApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialMediaApp.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Like, LikeDTO>().ReverseMap();
        }
    }
}
