using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicLanguage.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_TR",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description_TR",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name_TR",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description_TR",
                table: "Categories",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Name_TR");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Description_TR");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Name_TR");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "Description_TR");
        }
    }
}
