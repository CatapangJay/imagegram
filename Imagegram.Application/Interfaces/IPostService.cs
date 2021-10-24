using Imagegram.Application.DTOs;
using Imagegram.Application.DTOs.Comment;
using Imagegram.Application.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Interfaces
{
    public interface IPostService
    {
        public Task<List<PostDto>> GetAll();
        public Task<List<PostsWithCommentsDto>> GetAllOrderByComments();
        public Task<PostDto> Get(int id);
        public Task<int> Create(PostDto postDto);
        public Task Update(int id, PostDto postDto);
        public Task<bool> Delete(int id);
        public Task<bool> AddComment(int postId, CommentDto commentDto);
        public Task<bool> DeleteComment(int postId, CommentDto commentDto);
    }
}
