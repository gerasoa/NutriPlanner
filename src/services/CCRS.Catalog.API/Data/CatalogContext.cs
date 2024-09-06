//using CCRS.Catalog.API.Migrations;
using CCRS.Catalog.API.Models;
using CCRS.Core.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;

namespace CCRS.Catalog.API.Data
{
    public class CatalogContext : DbContext, IUnifOfWork
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) 
            : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientMeasure> IngredientMeasures { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<RecipeDirection> RecipeDirections { get; set; }        
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<IngredientDirection> IngredientDirections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) 
                property.SetColumnType("varchar(200)");

            //Difficulty
            modelBuilder.Entity<Recipe>()
               .HasOne(r => r.Difficulty) // Receita tem uma Difficulty
               .WithMany(r => r.Recipe) // Difficulty tem muitas Recipes
               .HasForeignKey(c => c.DifficultyId) // Chave estrangeira na Receita
               .OnDelete(DeleteBehavior.Restrict); // Configuração de exclusão

            //Category
            modelBuilder.Entity<Recipe>()
               .HasOne(r => r.Category)
               .WithMany(r => r.Recipe)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
            
            //Feedback
            modelBuilder.Entity<Feedback>()
               .HasOne(r => r.Recipe)
               .WithMany(r => r.Feedbacks)
               .HasForeignKey(c => c.RecipeId)
               .OnDelete(DeleteBehavior.Restrict);

            //RecipeDirection - Recipes
            modelBuilder.Entity<RecipeDirection>()
                .HasOne(r => r.Recipe)
                .WithMany(r => r.RecipeDirections)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            //RecipeDirections - IngredientDirections
            modelBuilder.Entity<IngredientDirection>()
                .HasOne(r => r.RecipeDirection)
                .WithMany(r => r.IngredientDirections)
                .HasForeignKey(r => r.RecipeDirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            //IngredientMeasure - IngredientDirections
            modelBuilder.Entity<IngredientDirection>()
                .HasOne(r => r.IngredientMeasure)
                .WithMany(r => r.IngredientDirections)
                .HasForeignKey(r => r.IngredientMeasureId)
                .OnDelete(DeleteBehavior.Restrict);

            //Ingredient - IngredientMeasure
           modelBuilder.Entity<IngredientMeasure>()
                .HasOne(r => r.Ingredient)
                .WithMany(r => r.IngredientMeasures)
                .HasForeignKey(r => r.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            //Measure - IngredientMeasure
            modelBuilder.Entity<IngredientMeasure>()
                 .HasOne(r => r.Measure)
                 .WithMany(r => r.IngredientMeasure)
                 .HasForeignKey(r => r.MeasureId)
                 .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Direction>()
                .HasOne(r => r.RecipeDirection)
                .WithMany(r => r.Directions)
                .HasForeignKey(r => r.RecipeDirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
