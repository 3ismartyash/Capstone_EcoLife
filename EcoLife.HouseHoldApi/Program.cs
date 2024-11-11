
using EcoLife.HouseHoldApi.Data;
using EcoLife.HouseHoldApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.HouseHoldApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<HouseHoldDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ELHouseHoldDB")));    
            builder.Services.AddTransient<IHouseHoldRepository, HouseHoldRepository>();
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
