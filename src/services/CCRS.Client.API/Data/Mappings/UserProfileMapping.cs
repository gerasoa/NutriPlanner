using CCRS.Core.DomainObjects;
using CCRS.User.API.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCRS.User.API.Models.Data.Mappings
{
    public class UserProfileMapping : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.NumCertifiction)                
                .HasColumnType("varchar(50)");

            builder.Property(c => c.CountryCertification)
                .HasColumnType("varchar(150)");

            //The UserProfile has one Cpf
            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Number)
                .IsRequired()
                .HasMaxLength(Cpf.cpfLength)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.cpfLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.AddressMaxLenght})");
            });

            builder.HasOne(c => c.Address)
                .WithOne(c => c.UserProfile);

            builder.ToTable("UserProfile");
        }
    }
}
