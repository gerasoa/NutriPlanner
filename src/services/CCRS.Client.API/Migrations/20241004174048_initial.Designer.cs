﻿// <auto-generated />
using System;
using CCRS.User.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CCRS.User.API.Migrations
{
    [DbContext(typeof(UserProfessionalContext))]
    [Migration("20241004174048_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CCRS.User.API.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserProfessionalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserProfessionalId")
                        .IsUnique();

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("CCRS.User.API.Models.UserProfessional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfCertification")
                        .HasColumnType("varchar(150)");

                    b.Property<DateOnly>("DoB")
                        .HasColumnType("date");

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nacionality")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NutritionistCouncilNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Profession")
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("UserProfessional", (string)null);
                });

            modelBuilder.Entity("CCRS.User.API.Models.Address", b =>
                {
                    b.HasOne("CCRS.User.API.Models.UserProfessional", "UserProfessional")
                        .WithOne("Address")
                        .HasForeignKey("CCRS.User.API.Models.Address", "UserProfessionalId")
                        .IsRequired();

                    b.Navigation("UserProfessional");
                });

            modelBuilder.Entity("CCRS.User.API.Models.UserProfessional", b =>
                {
                    b.OwnsOne("CCRS.Core.DomainObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UserProfessionalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Cpf");

                            b1.HasKey("UserProfessionalId");

                            b1.ToTable("UserProfessional");

                            b1.WithOwner()
                                .HasForeignKey("UserProfessionalId");
                        });

                    b.OwnsOne("CCRS.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserProfessionalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(254)")
                                .HasColumnName("Email");

                            b1.HasKey("UserProfessionalId");

                            b1.ToTable("UserProfessional");

                            b1.WithOwner()
                                .HasForeignKey("UserProfessionalId");
                        });

                    b.Navigation("Cpf");

                    b.Navigation("Email");
                });

            modelBuilder.Entity("CCRS.User.API.Models.UserProfessional", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
