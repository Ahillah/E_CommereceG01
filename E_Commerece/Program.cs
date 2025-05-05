

using Abstraction;
using Domain.Contruct;
using E_Commerece.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistance.Repositories;
using Service;

namespace E_Commerece
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext < StoreDBContext>(
                
                options=>
                {
                    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                    options.UseSqlServer(ConnectionString);


                });
                  



            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AssemblyReferences).Assembly);
            builder.Services.AddScoped<IServicesManager, ServiceManager>();
            var app = builder.Build();
            await initilizeDbAsync(app);

            // Configure the HTTP request pipeline.
            app.UseMiddleware<CustomExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
               
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseStaticFiles();

            app.Run();
        }
        public static async Task initilizeDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();


            var dbInializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInializer.initializeAsync();
        }
    }
}
