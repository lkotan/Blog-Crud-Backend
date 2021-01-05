using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.DataAccess.Migrations
{
    public partial class deletePhotoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Blogs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "space(0)");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Authors",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValueSql: "space(0)");
        }
    }
}
