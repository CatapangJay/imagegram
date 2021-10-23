using Imagegram.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Application.DTOs
{
    public class PostDto : BaseDto
    {
        public ImgramUserDto User { get; set; }
        public string Caption { get; set; }
        public string ImgPath { get; set; }
    }
}
