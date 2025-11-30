using Ecommerce.Core;
using Ecommerce.Core.Mapper;
using ECommerce.Api.Middlewares;
using ECommerce.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddAutoMapper(cfg => { }, typeof(UserMapperProfile).Assembly);

            builder.Services.AddFluentValidationAutoValidation();


            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
