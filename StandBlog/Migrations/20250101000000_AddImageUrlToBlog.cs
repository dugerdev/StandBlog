using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "app",
                table: "Blogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "app",
                table: "Blogs");
        }
    }
}

