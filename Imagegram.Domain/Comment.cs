using Imagegram.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Domain
{
    public class Comment : BaseDomainEntity
    {
        public string Text { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int? UserId { get; set; }
        public ImgramUser User { get; set; }
    }
}
