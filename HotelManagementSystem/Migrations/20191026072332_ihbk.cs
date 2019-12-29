using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class ihbk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "UserContacts",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddColumn<string>(
                name: "ReplyMessage",
                table: "UserContacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplyMessage",
                table: "UserContacts");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateTime",
                table: "UserContacts",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
