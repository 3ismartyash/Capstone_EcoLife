
using EcoLife.RecommendationApi.Data;
using EcoLife.RecommendationApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.RecommendationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<RecommendationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ELRecommendationDB")));   
            builder.Services.AddTransient<IRecommendationRepository,RecommendationRepository>();
           
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            var app = builder.Build();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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
