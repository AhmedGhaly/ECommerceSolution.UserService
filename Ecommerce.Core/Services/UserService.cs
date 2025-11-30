using AutoMapper;
using Ecommerce.Core.Dto;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Mapper;
using Ecommerce.Core.RepositoriesContract;
using Ecommerce.Core.ServicesContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this._mapper = mapper;

        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            User? user = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user is null)
                return null;
            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Token = " token",
                sucess = true
            };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            User? user = await userRepository.AddNewUser(new User()
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString()
            });
            if(user is null) return null;
            return _mapper.Map<AuthenticationResponse>(user) with
            {
                Token = " token",
                sucess = true
            };
        }
    }
}
