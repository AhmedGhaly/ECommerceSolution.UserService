using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.RepositoriesContract
{
    public interface IUserRepository
    {
        Task<User?> AddNewUser(User user);
        Task<User?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
