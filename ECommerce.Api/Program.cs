using Ecommerce.Core;
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

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
