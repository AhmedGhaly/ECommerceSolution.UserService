using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommerce.Infrastructure.DBContext
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;
        public DapperDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? conntectionString = _configuration.GetConnectionString("PostgresConnection");

            _dbConnection = new NpgsqlConnection(conntectionString);
        }

        public IDbConnection DbConnection { get { return _dbConnection; } }
    }
}
