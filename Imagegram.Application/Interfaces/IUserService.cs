using Imagegram.Application.DTOs;
using Imagegram.Application.DTOs.ImgramUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Interfaces
{
    public interface IUserService
    {
        public Task<List<ImgramUserDto>> GetAll();
        public Task<ImgramUserDto> Get(int id);
        public Task<int> Create(ImgramUserDto postDto);
        public Task<int> Update(int id, ImgramUserDto postDto);
        public Task<bool> Delete(int id);
    }
}
