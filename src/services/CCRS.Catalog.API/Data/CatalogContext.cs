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

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Measure> Measure { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Difficulty> Dificulty { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<DirectionsGroup> DirectionsGroup { get; set; }        
        public DbSet<Feedback> Feedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) 
                property.SetColumnType("varchar(200)");

            modelBuilder.Entity<Recipe>()
               .HasOne(r => r.Category)
               .WithMany()
               .HasForeignKey(r => r.CategoryId)
               .OnDelete(DeleteBehavior.Restrict); // Defina o comportamento de deleção

            //Configuração da relação entre Recipe e Feedback
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Feedbacks)
                .WithOne(f => f.Recipe)
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento em caso de exclusão

            // Configuração da relação entre Feedback e User (se a entidade User existir)
            //modelBuilder.Entity<Feedback>()
            //    .HasOne<User>()  // Inclua o tipo User se a entidade User estiver definida
            //    .WithMany(u => u.Feedback)
            //    .HasForeignKey(f => f.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento em caso de exclusão


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);

        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
