using AutoMapper;
using GlobalInsightsTribune.Application.DTOs;
using GlobalInsightsTribune.Application.Interfaces;
using GlobalInsightsTribune.Domain.Entities;
using GlobalInsightsTribune.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalInsightsTribune.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository , IMapper mapper) { 
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void RegisterUser(UserDTO user)
        {
            var mapUser = _mapper.Map<User>(user);
            _userRepository.RegisterUser(mapUser);
        }

        public IEnumerable<UserDTO> GetUserAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_userRepository.GetUserAll());
        }
    }
}
