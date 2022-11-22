using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class SellsAndDetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SellDetailId",
                table: "PartidesInStores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContragentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sells_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sells_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellDetails_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellDetails_Sells_SellId",
                        column: x => x.SellId,
                        principalTable: "Sells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartidesInStores_SellDetailId",
                table: "PartidesInStores",
                column: "SellDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_ArticleId",
                table: "SellDetails",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_SellId",
                table: "SellDetails",
                column: "SellId");

            migrationBuilder.CreateIndex(
                name: "IX_SellDetails_UnitId",
                table: "SellDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_ContragentId",
                table: "Sells",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sells_StoreId",
                table: "Sells",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartidesInStores_SellDetails_SellDetailId",
                table: "PartidesInStores",
                column: "SellDetailId",
                principalTable: "SellDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartidesInStores_SellDetails_SellDetailId",
                table: "PartidesInStores");

            migrationBuilder.DropTable(
                name: "SellDetails");

            migrationBuilder.DropTable(
                name: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_PartidesInStores_SellDetailId",
                table: "PartidesInStores");

            migrationBuilder.DropColumn(
                name: "SellDetailId",
                table: "PartidesInStores");
        }
    }
}
