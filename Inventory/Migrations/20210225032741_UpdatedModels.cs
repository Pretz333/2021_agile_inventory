using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_LocationID",
                table: "Category",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Location_LocationID",
                table: "Category",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Location_LocationID",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_LocationID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Category");
        }
    }
}
