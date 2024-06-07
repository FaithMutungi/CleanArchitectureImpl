using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using MinimalApi.Abstractions;

namespace MinimalApi.Extensions
{
    public static class MinimalApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder
            )
        {

            builder.Services.AddDbContext<SocialDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
               ));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePost).Assembly));

        }
        public static void RegisterEndpointDefinition(this WebApplication app){
            var endpointDefinitions = typeof(Program).Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IEndPointDefinition)) &&
                !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndPointDefinition>();
            foreach (var endpontDef in endpointDefinitions)
            {
                endpontDef.RegisterEndPoints(app);  
            }
        }
    }
}
