using AutoMapper;
using Imagegram.Application.Contracts.Persistence;
using Imagegram.Application.DTOs.Comment;
using Imagegram.Application.Interfaces;
using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task AddComment(CommentDto commentDto)
        {
            await _commentRepository.Add(_mapper.Map<Comment>(commentDto));
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CommentDto> Get(int id)
        {
            var comment = await _commentRepository.Get(id);

            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<List<CommentDto>> GetAll()
        {
            var comments = await _commentRepository.GetAll();

            return _mapper.Map<List<CommentDto>>(comments);
        }

        public Task<bool> UpdateComment(int id, CommentDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
