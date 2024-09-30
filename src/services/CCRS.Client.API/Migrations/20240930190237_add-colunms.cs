using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCRS.User.API.Migrations
{
    /// <inheritdoc />
    public partial class addcolunms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserProfile",
                type: "varchar(254)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(254)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "UserProfile",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<string>(
                name: "CountryCertification",
                table: "UserProfile",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumCertifiction",
                table: "UserProfile",
                type: "varchar(200)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCertification",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "NumCertifiction",
                table: "UserProfile");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserProfile",
                type: "varchar(254)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(254)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "UserProfile",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
