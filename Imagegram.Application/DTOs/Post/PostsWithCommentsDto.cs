using Imagegram.Application.DTOs.Comment;
using Imagegram.Application.DTOs.Common;
using Imagegram.Application.DTOs.ImgramUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.DTOs.Post
{
    public class PostsWithCommentsDto : BaseDto
    {
        public string Caption { get; set; }
        public string ImgPath { get; set; }

        public ICollection<CommentDetailsDto> Comments { get; set; }
        public ImgramUserDto User { get; set; }
    }
}
