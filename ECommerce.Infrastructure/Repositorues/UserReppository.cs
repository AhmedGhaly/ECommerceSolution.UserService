using Ecommerce.Core.Dto;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositorues
{
    internal class UserReppository : IUserRepository
    {
        public async Task<User?> AddNewUser(User user)
        {
            user.Id = Guid.NewGuid();
            return user;
        }

        public async Task<User?> GetUserByEmailAndPassword(string? email, string? password)
        {
            return new User
            {
                Email = email,
                Password = password,
                Id = Guid.NewGuid(),
                Gender = GenderOptions.Male.ToString(),
                Name = "Ahmed"
            };
        }
    }
}
