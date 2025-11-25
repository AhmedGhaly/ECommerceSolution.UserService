using Ecommerce.Core;
using ECommerce.Api.Middlewares;
using ECommerce.Infrastructure;

namespace ECommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure();
            builder.Services.AddCore();


            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();


            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
