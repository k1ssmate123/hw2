
using foodAPI.Data;
using foodAPI.Logic;
using foodAPI.Logic.Food;
using foodAPI.Logic.IngredientLogic;
using Microsoft.EntityFrameworkCore;

namespace foodAPI
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
            builder.Services.AddTransient(typeof(Repository<>));
            builder.Services.AddTransient<FoodLogic>();
            builder.Services.AddTransient<IngredientLogic>();
            builder.Services.AddTransient<IngredientAmountLogic>();
            builder.Services.AddTransient<DtoProvider>();

            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FoodDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True")
                .UseLazyLoadingProxies();
            });
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
