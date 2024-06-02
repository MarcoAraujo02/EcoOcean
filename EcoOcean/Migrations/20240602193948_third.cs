using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoOcean.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Voluntario",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Voluntario",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Voluntario");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Voluntario");
        }
    }
}
