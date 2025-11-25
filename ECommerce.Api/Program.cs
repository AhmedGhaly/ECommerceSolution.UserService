using Ecommerce.Core;
using ECommerce.Api.Middlewares;
using ECommerce.Infrastructure;
using System.Text.Json.Serialization;

namespace ECommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            


            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure();
            builder.Services.AddCore();


            builder.Services.AddControllers().AddJsonOptions(op => op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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
