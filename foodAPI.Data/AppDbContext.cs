using foodAPI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace foodAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<IngredientAmount> IngredientAmount { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<IngredientAmount>()
                .HasOne(ia => ia.FoodItem)
                .WithMany(f => f.IngredientAmounts)
                .HasForeignKey(ia => ia.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<IngredientAmount>()
                .HasOne(ia => ia.Ingredient)
                .WithMany(i => i.IngredientAmounts)
                .HasForeignKey(ia => ia.IngredientId)
                .OnDelete(DeleteBehavior.Cascade); 

        
            base.OnModelCreating(modelBuilder);
        }
    }
}
