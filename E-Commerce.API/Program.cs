using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure;
using E_Commerce.Infrastructure.DataSeed;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<E_commerceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            
            //
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbContext = services.GetRequiredService<E_commerceContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                //region Apply Migration Automatically
                _dbContext.Database.Migrate();
                DataSeeding.AddData(_dbContext);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            }
            finally
            {
                // Optional: Dispose of any resources if needed
                // Or use "using var scope = app.Services.CreateScope();" to avoid this
                scope.Dispose();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
