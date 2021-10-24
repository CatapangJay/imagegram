using Imagegram.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Domain
{
    public class ImgramUser : BaseDomainEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
