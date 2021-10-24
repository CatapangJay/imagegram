using Imagegram.Application.DTOs;
using Imagegram.Application.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Interfaces
{
    public interface ICommentService
    {
        public Task<List<CommentDto>> GetAll();
        public Task<CommentDto> Get(int id);
        public Task AddComment(CommentDto commentDto);
        public Task<bool> UpdateComment(int id, CommentDto postDto);
        public Task<bool> Delete(int id);
    }
}
