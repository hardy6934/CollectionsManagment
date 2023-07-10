using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionsManagment.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSenderIdToUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Likes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Comments",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Likes",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "SenderId");
        }
    }
}
