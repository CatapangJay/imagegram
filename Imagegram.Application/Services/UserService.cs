using AutoMapper;
using Imagegram.Application.DTOs;
using Imagegram.Application.Interfaces;
using Imagegram.Application.Persistence.Contracts;
using Imagegram.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IImgramUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IImgramUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ImgramUserDto userDto)
        {
            var createdUser = await _userRepository.Add(_mapper.Map<ImgramUser>(userDto));

            return createdUser.Id;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ImgramUserDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImgramUserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(int id, ImgramUserDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
