using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class PartidesInStoresLinkFixedV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partides_PartidesInStores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Partides");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_PartidesInStores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Partides_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Partides");

            migrationBuilder.DropColumn(
                name: "PartidesInStorePartideId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PartidesInStoreStoreId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PartidesInStorePartideId",
                table: "Partides");

            migrationBuilder.DropColumn(
                name: "PartidesInStoreStoreId",
                table: "Partides");

            migrationBuilder.CreateIndex(
                name: "IX_PartidesInStores_PartideId",
                table: "PartidesInStores",
                column: "PartideId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartidesInStores_Partides_PartideId",
                table: "PartidesInStores",
                column: "PartideId",
                principalTable: "Partides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartidesInStores_Stores_StoreId",
                table: "PartidesInStores",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_Partides_PartideId",
                table: "PartidesInStores");

            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_Stores_StoreId",
                table: "PartidesInStores");

            migrationBuilder.DropIndex(
                name: "IX_PartidesInStores_PartideId",
                table: "PartidesInStores");

            migrationBuilder.AddColumn<Guid>(
                name: "PartidesInStorePartideId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidesInStoreStoreId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidesInStorePartideId",
                table: "Partides",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidesInStoreStoreId",
                table: "Partides",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Stores",
                columns: new[] { "PartidesInStoreStoreId", "PartidesInStorePartideId" });

            migrationBuilder.CreateIndex(
                name: "IX_Partides_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Partides",
                columns: new[] { "PartidesInStoreStoreId", "PartidesInStorePartideId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Partides_PartidesInStores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Partides",
                columns: new[] { "PartidesInStoreStoreId", "PartidesInStorePartideId" },
                principalTable: "PartidesInStores",
                principalColumns: new[] { "StoreId", "PartideId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_PartidesInStores_PartidesInStoreStoreId_PartidesInStorePartideId",
                table: "Stores",
                columns: new[] { "PartidesInStoreStoreId", "PartidesInStorePartideId" },
                principalTable: "PartidesInStores",
                principalColumns: new[] { "StoreId", "PartideId" });
        }
    }
}
