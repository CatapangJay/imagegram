using Imagegram.Domain.Common;
using System;
using System.Collections.Generic;

namespace Imagegram.Domain
{
    public class Post : BaseDomainEntity
    {
        public ImgramUser User { get; set; }
        public string Caption { get; set; }
        public string ImgPath { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
