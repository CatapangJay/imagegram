using Imagegram.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Interfaces
{
    public interface ICommentService
    {
        public Task<List<PostDto>> GetAll();
        public Task<PostDto> Get(int id);
        public Task<bool> AddComment(int postId, CommentDto commentDto);
        public Task<bool> UpdateComment(int id, PostDto postDto);
        public Task<bool> Delete(int id);
    }
}
