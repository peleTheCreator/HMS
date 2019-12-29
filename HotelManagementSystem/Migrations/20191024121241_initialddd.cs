using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class initialddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrderId",
                table: "ProductPurchaseOrderTracking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchaseOrderTracking_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPurchaseOrderTracking_PurchaseOrders_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchaseOrderTracking_PurchaseOrders_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking");

            migrationBuilder.DropIndex(
                name: "IX_ProductPurchaseOrderTracking_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderId",
                table: "ProductPurchaseOrderTracking");
        }
    }
}
