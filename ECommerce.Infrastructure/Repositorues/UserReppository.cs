using Dapper;
using Ecommerce.Core.Dto;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoriesContract;
using ECommerce.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositorues
{
    internal class UserReppository : IUserRepository
    {
        private readonly DapperDBContext _dbContext;

        public UserReppository(DapperDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> AddNewUser(User user)
        {
            user.Id = Guid.NewGuid();

            string query = "INSRT INTO public.\"Users\" (\"UserId\", \"Name\",\"Email\", \"Password\", \"Gender\") VALUES (@Id, @Name, @Email,@Password, @Gender) ";

            var rowAffect = await _dbContext.DbConnection.ExecuteAsync(query);
            if(rowAffect > 0)
                return user;
            return null;
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
