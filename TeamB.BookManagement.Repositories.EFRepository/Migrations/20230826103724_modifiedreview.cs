using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamB.BookManagement.Repositories.EFRepository.Migrations
{
    /// <inheritdoc />
    public partial class modifiedreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_Id",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
