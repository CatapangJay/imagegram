using Imagegram.Application.DTOs.Common;
using Imagegram.Application.DTOs.ImgramUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.DTOs
{
    public class CommentDetailsDto : BaseDto
    {
        public ImgramUserDto User { get; set; }
        public string Text { get; set; }
    }
}
