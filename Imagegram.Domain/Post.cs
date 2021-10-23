using Imagegram.Domain.Common;
using System;
using System.Collections.Generic;

namespace Imagegram.Domain
{
    public class Post : BaseDomainEntity
    {
        public string Caption { get; set; }
        public string ImgPath { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
