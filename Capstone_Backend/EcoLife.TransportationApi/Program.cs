
using EcoLife.TransportationApi.Data;
using EcoLife.TransportationApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.TransportationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<TransportationDbContext>(options =>
            options.UseSqlServer (builder.Configuration.GetConnectionString("ELTransportationDB")));

            builder.Services.AddTransient<ITransportationRepository, TransportationRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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