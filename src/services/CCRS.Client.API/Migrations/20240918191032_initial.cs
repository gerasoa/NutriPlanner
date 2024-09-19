using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCRS.User.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false),
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UserProfileId",
                table: "Enderecos",
                column: "UserProfileId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
