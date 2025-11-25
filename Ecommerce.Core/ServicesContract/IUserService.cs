using Ecommerce.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.ServicesContract
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    }
}
