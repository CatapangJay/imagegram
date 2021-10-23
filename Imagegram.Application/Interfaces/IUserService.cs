using Imagegram.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Interfaces
{
    public interface IUserService
    {
        public Task<List<PostDto>> GetAll();
        public Task<PostDto> Get(int id);
        public Task<int> Create(PostDto postDto);
        public Task<int> Update(int id, PostDto postDto);
        public Task<bool> Delete(int id);
    }
}
