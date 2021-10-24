using Imagegram.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imagegram.Application.DTOs.Post
{
    public class PostDto : BaseDto
    {
        public int UserId { get; set; }

        [StringLength(120)]
        public string Caption { get; set; }

        public string ImgPath { get; set; }
    }
}
