using CCRS.Core.DomainObjects;
//using CCRS.User.API.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCRS.User.API.Models.Data.Mappings
{
    public class UserProfessionalMapping : IEntityTypeConfiguration<UserProfessional>
    {
        public void Configure(EntityTypeBuilder<UserProfessional> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.NutritionistCouncilNumber)                
                .HasColumnType("varchar(50)");

            builder.Property(c => c.CountryOfCertification)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Profession)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Nacionality)
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Gender)
               .HasColumnType("varchar(150)");

            builder.Property(c => c.Phone)
              .HasColumnType("varchar(150)");



        //The UserProfessional has one Cpf
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
                .WithOne(c => c.UserProfessional);

            builder.ToTable("UserProfessional");
        }
    }
}
