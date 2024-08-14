using CCRS.Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCRS.Catalog.API.Data.Mappings
{
    public class RecipeMapping : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Summary)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.ToTable("Recipes");
        }
    }
}
