using Imagegram.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Domain
{
    public class Comment : BaseDomainEntity
    {
        public ImgramUser User { get; set; }
        public string Text { get; set; }
    }
}
