using AutoMapper;
using Imagegram.Application.Contracts.Persistence;
using Imagegram.Application.DTOs.ImgramUser;
using Imagegram.Application.Interfaces;
using Imagegram.Domain;
using System;
using System.Collections.Generic;
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

        public async Task<ImgramUserDto> Get(int id)
        {
            var existingUser = await _userRepository.Get(id);

            return _mapper.Map<ImgramUserDto>(existingUser);
        }

        public async Task<List<ImgramUserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<List<ImgramUserDto>>(users);
        }


        public Task<int> Update(int id, ImgramUserDto postDto)
        {
            throw new NotImplementedException();
        }
    }
}
