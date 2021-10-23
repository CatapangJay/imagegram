using Imagegram.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.DTOs
{
    public class CommentDto : BaseDto
    {
        public ImgramUserDto User { get; set; }
        public string Text { get; set; }
    }
}
