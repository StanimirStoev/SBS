using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class DeliveryAddedPartidesRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_Partides_PartideId",
                table: "PartidesInStores");

            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_Stores_StoreId",
                table: "PartidesInStores");

            migrationBuilder.DropTable(
                name: "Partides");

            migrationBuilder.RenameColumn(
                name: "PartideId",
                table: "PartidesInStores",
                newName: "DeliveryDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_PartidesInStores_PartideId",
                table: "PartidesInStores",
                newName: "IX_PartidesInStores_DeliveryDetailId");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliveries_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ContragentId",
                table: "Deliveries",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_StoreId",
                table: "Deliveries",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_ArticleId",
                table: "DeliveryDetails",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_DeliveryId",
                table: "DeliveryDetails",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartidesInStores_DeliveryDetails_DeliveryDetailId",
                table: "PartidesInStores",
                column: "DeliveryDetailId",
                principalTable: "DeliveryDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartidesInStores_Stores_StoreId",
                table: "PartidesInStores",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_DeliveryDetails_DeliveryDetailId",
                table: "PartidesInStores");

            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_Stores_StoreId",
                table: "PartidesInStores");

            migrationBuilder.DropTable(
                name: "DeliveryDetails");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "DeliveryDetailId",
                table: "PartidesInStores",
                newName: "PartideId");

            migrationBuilder.RenameIndex(
                name: "IX_PartidesInStores_DeliveryDetailId",
                table: "PartidesInStores",
                newName: "IX_PartidesInStores_PartideId");

            migrationBuilder.CreateTable(
                name: "Partides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partides_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partides_ArticleId",
                table: "Partides",
                column: "ArticleId");

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
    }
}
