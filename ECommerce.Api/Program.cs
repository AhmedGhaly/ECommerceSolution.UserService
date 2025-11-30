using Ecommerce.Core;
using Ecommerce.Core.Mapper;
using ECommerce.Api.Middlewares;
using ECommerce.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
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

            //builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApiDocument(config => { config.Title = "Ecommerce.Api"; config.Description = "this api created By Ahmed Ghaly"; });

            //builder.Services.AddSwaggerGen();



            var app = builder.Build();
            app.UseExceptionHandlingMiddleware();

            app.UseOpenApi();
            //app.UseSwagger();
            app.UseSwaggerUI();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
