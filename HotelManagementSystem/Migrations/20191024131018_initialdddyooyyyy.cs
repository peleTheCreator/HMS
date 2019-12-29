using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class initialdddyooyyyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPurchaseOrderTracking_PurchaseOrders_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking");

            migrationBuilder.DropIndex(
                name: "IX_ProductPurchaseOrderTracking_PurchaseOrderId",
                table: "ProductPurchaseOrderTracking");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderId",
                table: "ProductPurchaseOrderTracking",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderId",
                table: "ProductPurchaseOrderTracking",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
