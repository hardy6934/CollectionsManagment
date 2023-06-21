using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionsManagment.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhotoColumtToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Users");
        }
    }
}
