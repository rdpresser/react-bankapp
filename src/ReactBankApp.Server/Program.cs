
using Microsoft.EntityFrameworkCore;
using ReactBank.Infra.Data.Context;

namespace ReactBankApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            ApplyMigration(app, app.Configuration);

            app.Run();
        }

        static void ApplyMigration(WebApplication app, IConfiguration configuration)
        {
            if (bool.Parse(configuration.GetConnectionString("UseInMemoryDatabase")!))
            {
                return;
            }

            using var scope = app.Services.CreateScope();
            var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (_db != null)
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
        }
    }
}
