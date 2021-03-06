using AutoMapper;
using Imagegram.Application.Contracts.Persistence;
using Imagegram.Application.DTOs.Comment;
using Imagegram.Application.DTOs.Post;
using Imagegram.Application.Interfaces;
using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public Task<bool> AddComment(int postId, CommentDto commentDto)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(PostDto postDto)
        {
            var createdPost = await _postRepository.Add(_mapper.Map<Post>(postDto));

            return createdPost.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _postRepository.Get(id);

            if (post is null) return false;

            await _postRepository.Delete(post);

            return true;
        }

        public Task<bool> DeleteComment(int postId, CommentDto commentDto)
        {
            throw new NotImplementedException();
        }

        public async Task<PostDto> Get(int id)
        {
            var post = await _postRepository.Get(id);

            return _mapper.Map<PostDto>(post);
        }

        public async Task<List<PostDto>> GetAll()
        {
            var posts = await _postRepository.GetAll();

            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<List<PostsWithCommentsDto>> GetAllOrderByComments()
        {
            // TODO: Implement cursor pagination
            var posts = await _postRepository.GetPostsOrderByCommentCount("");

            return _mapper.Map<List<PostsWithCommentsDto>>(posts);
        }

        public async Task Update(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            await _postRepository.Update(post);
        }
    }
}
