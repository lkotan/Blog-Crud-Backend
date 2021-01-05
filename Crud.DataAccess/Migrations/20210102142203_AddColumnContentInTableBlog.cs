using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.DataAccess.Migrations
{
    public partial class AddColumnContentInTableBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                nullable: false,
                defaultValueSql: "space(0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");
        }
    }
}
