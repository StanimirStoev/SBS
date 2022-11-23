using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class SellDetailChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellDetails_Articles_ArticleId",
                table: "SellDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellDetails_ArticleId",
                table: "SellDetails");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "SellDetails",
                newName: "StoreId");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryDetailId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_StoreId_DeliveryDetailId",
                table: "SellDetails",
                columns: new[] { "StoreId", "DeliveryDetailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SellDetails_PartidesInStores_StoreId_DeliveryDetailId",
                table: "SellDetails",
                columns: new[] { "StoreId", "DeliveryDetailId" },
                principalTable: "PartidesInStores",
                principalColumns: new[] { "StoreId", "DeliveryDetailId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellDetails_PartidesInStores_StoreId_DeliveryDetailId",
                table: "SellDetails");

            migrationBuilder.DropIndex(
                name: "IX_SellDetails_StoreId_DeliveryDetailId",
                table: "SellDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDetailId",
                table: "SellDetails");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "SellDetails",
                newName: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_ArticleId",
                table: "SellDetails",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellDetails_Articles_ArticleId",
                table: "SellDetails",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
