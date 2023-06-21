using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class changeCatalogItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogItems_CatalogItemId",
                table: "CatalogItems");

            migrationBuilder.RenameColumn(
                name: "CatalogItemId",
                table: "CatalogItems",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogItems_CatalogItemId",
                table: "CatalogItems",
                newName: "IX_CatalogItems_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogItems_ParentId",
                table: "CatalogItems",
                column: "ParentId",
                principalTable: "CatalogItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItems_CatalogItems_ParentId",
                table: "CatalogItems");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "CatalogItems",
                newName: "CatalogItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogItems_ParentId",
                table: "CatalogItems",
                newName: "IX_CatalogItems_CatalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItems_CatalogItems_CatalogItemId",
                table: "CatalogItems",
                column: "CatalogItemId",
                principalTable: "CatalogItems",
                principalColumn: "Id");
        }
    }
}
