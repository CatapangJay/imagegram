using Imagegram.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.DTOs.Comment
{
    public class CommentDto : BaseDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
    }
}
