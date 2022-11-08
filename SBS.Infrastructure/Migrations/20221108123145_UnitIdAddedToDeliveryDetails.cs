using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class UnitIdAddedToDeliveryDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UnitId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_UnitId",
                table: "DeliveryDetails",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryDetails_Units_UnitId",
                table: "DeliveryDetails",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryDetails_Units_UnitId",
                table: "DeliveryDetails");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryDetails_UnitId",
                table: "DeliveryDetails");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "DeliveryDetails");
        }
    }
}
