using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionsManagment.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class TagsFromCollectionsToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Collections_CollectionId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "Tags",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_CollectionId",
                table: "Tags",
                newName: "IX_Tags_ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ItemID",
                table: "Tags",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ItemID",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Tags",
                newName: "CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ItemID",
                table: "Tags",
                newName: "IX_Tags_CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Collections_CollectionId",
                table: "Tags",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
