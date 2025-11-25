using Ecommerce.Core.Dto;
using Ecommerce.Core.Entities;
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

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            User? user = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user is null)
                return null;
            return new AuthenticationResponse(
                 user.Id,
                 user.Name,
               loginRequest.Email,
                  user.Gender,
                "this is a token",
                  true
                );
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            User? user = await userRepository.AddNewUser(new User()
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
            });
            if(user is null) return null;
            return new AuthenticationResponse( 
                user.Id,
                registerRequest.Name,
                registerRequest.Email,
               GenderOptions.Male.ToString(),
                "token",
                 true
            );
        }
    }
}
