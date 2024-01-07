using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicLanguage.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_TR",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_EN",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_TR",
                table: "Categories",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_TR",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description_EN",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description_TR",
                table: "Categories");
        }
    }
}
