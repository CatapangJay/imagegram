using AutoMapper;
using Imagegram.Application.DTOs;
using Imagegram.Application.DTOs.Comment;
using Imagegram.Application.DTOs.ImgramUser;
using Imagegram.Application.DTOs.Post;
using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<ImgramUser, ImgramUserDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostsWithCommentsDto>();
            CreateMap<Comment, CommentDetailsDto>();
        }
    }
}
