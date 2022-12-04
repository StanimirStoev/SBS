using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class AddCommentsAndSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Units",
                comment: "Measuring units");

            migrationBuilder.AlterTable(
                name: "Transfers",
                comment: "Transfer Data");

            migrationBuilder.AlterTable(
                name: "TransferDetails",
                comment: "Deatails for the Transfers");

            migrationBuilder.AlterTable(
                name: "Stores",
                comment: "Store Data");

            migrationBuilder.AlterTable(
                name: "Sells",
                comment: "Data for a Sell");

            migrationBuilder.AlterTable(
                name: "SellDetails",
                comment: "Deatails for the Sells");

            migrationBuilder.AlterTable(
                name: "PartidesInStores",
                comment: "Partides quantity in the stores");

            migrationBuilder.AlterTable(
                name: "DeliveryDetails",
                comment: "Deatails for the Delivery");

            migrationBuilder.AlterTable(
                name: "Deliveries",
                comment: "Data for a Delivery");

            migrationBuilder.AlterTable(
                name: "Countries",
                comment: "Data for a Country");

            migrationBuilder.AlterTable(
                name: "Contragents",
                comment: "Data for a Contragent (Client or Supplier)");

            migrationBuilder.AlterTable(
                name: "Cities",
                comment: "Data for a City");

            migrationBuilder.AlterTable(
                name: "Articles",
                comment: "Data for a Article");

            migrationBuilder.AlterTable(
                name: "Addresses",
                comment: "Data for a Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                comment: "Unit Short Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Units",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use Units",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Units",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Unit Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Units",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Unit Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ToStoreId",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Tarnsfer destination store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Transfers",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "FromStoreId",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Tarnsfer source store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                comment: "Tarnsfer Date of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Tarnsfer Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransferId",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Parent Tarnsfer Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "TransferDetails",
                type: "float",
                nullable: false,
                comment: "Transfered Quantity",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TransferDetails",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Delivery Detail Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Tarnsfer Detail Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "Store Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stores",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use Store",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Stores",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "Store Description",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Address Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Sells",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Sells",
                type: "datetime2",
                nullable: false,
                comment: "DateTime of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Contargent (Client) Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Sell Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Unit Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Store Sell Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Parent Sell Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "SellDetails",
                type: "float",
                nullable: false,
                comment: "Quantity to sell",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "SellDetails",
                type: "float",
                nullable: false,
                comment: "Sell price",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "SellDetails",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "DeliveryDetail Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Sell Detail Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "PartidesInStores",
                type: "float",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "PartidesInStores",
                type: "uniqueidentifier",
                nullable: false,
                comment: "DeliveryDetail (Partide) Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "PartidesInStores",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Unit Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "DeliveryDetails",
                type: "float",
                nullable: false,
                comment: "Delivered Quantity",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DeliveryDetails",
                type: "float",
                nullable: false,
                comment: "Delivered Price",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DeliveryDetails",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Parent Delivery Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Article Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Delivery Detail Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Store Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                comment: "Flag for confermrd sell ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                comment: "DateTime of creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Contargent (Supplier) Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Delivery Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "Name of Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEu",
                table: "Countries",
                type: "bit",
                nullable: false,
                comment: "Flag for EU countries",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                comment: "Code of Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Country Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Contragents",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                comment: "Vat Number of Contragent (EGN when private person)",
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contragents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "Last Name of Contragent",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSupplier",
                table: "Contragents",
                type: "bit",
                nullable: false,
                comment: "Flag is the contragent can be supplier",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsClient",
                table: "Contragents",
                type: "bit",
                nullable: false,
                comment: "Flag is the contragent can be client",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Contragents",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contragents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "First Name of Contragent",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contragents",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Contragent Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "Name of City",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Country Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                comment: "City Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "Last Name of ApplicationUser",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "First Name of ApplicationUser",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Unit Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "Title of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "Name of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Articles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                comment: "Model of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "Description of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryNumber",
                table: "Articles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "Delivery Number of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Article Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "bit",
                nullable: false,
                comment: "Flag for deleted/in use ",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Country Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Contragent Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                comment: "City Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Addresses",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                comment: "Address Line 2 of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Addresses",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                comment: "Address Line 1 of Article",
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Address Identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "64c7e2a2-f704-4515-a294-13fa5e9b28a8", 0, "0415ccc6-41af-458d-be4f-5b780a7386bb", "dido@mail.com", true, "Диян", "Христов", false, null, "DIDO@MAIL.COM", "ДИДО", "AQAAAAEAACcQAAAAEAzpt5pRFGsLAvUFxTKkbI0YvZWOTlmMziSIWFTMfiyoe0G8liAvRhYrtBkiTLffnw==", null, false, "7c0c3fb1-cae9-499f-b9c4-8db5a4512fad", false, "Дидо" },
                    { "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47", 0, "8ba6fc30-77e0-4ce0-b788-6bb49aece6d0", "nikki@mail.com", true, "Николета", "Добрева", false, null, "NIKKI@MAIL.COM", "НИКИ", "AQAAAAEAACcQAAAAEOU8sUJLm2WoJJ7GIra7Q/Ocvyj/Xl04W75YboqIW/VG+35TtPcwAu+uOqpWmh85zA==", null, false, "118bc6ce-d61e-423d-84a5-353f5168a6ce", false, "Ники" },
                    { "81762cb3-03ed-415e-a81a-4b73c9fec1fb", 0, "7cfb767a-6192-47c0-ba54-acedee4ee094", "alex@mail.com", true, "Александър", "Нацов", false, null, "ALEX@MAIL.COM", "АЛЕКС", "AQAAAAEAACcQAAAAEN15C9XtD+NDZDDIRcuMWGfFZYNGdeQj6nOM5oFDN2c2daci8wsUb5I9+qglNL+zjA==", null, false, "530aeeec-99a0-4c8f-aa4c-91a8f4a4f762", false, "Алекс" },
                    { "c5798b10-2d39-479f-9e29-042ed2562c3f", 0, "cc88d059-b4a7-4ede-8125-85579aeeae02", "stefan@mail.com", true, "Стефан", "Великов", false, null, "STEFAN@MAIL.COM", "ЧЕФО", "AQAAAAEAACcQAAAAEEfa92qxajG9njt9xYOWjvlcrJU81wBtIOSBNukj3EcaAMTxERy2ixn5XNsUleNi8Q==", null, false, "a53d2605-9cd3-4dc0-825f-b4f46434028d", false, "Чефо" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64c7e2a2-f704-4515-a294-13fa5e9b28a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81762cb3-03ed-415e-a81a-4b73c9fec1fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5798b10-2d39-479f-9e29-042ed2562c3f");

            migrationBuilder.AlterTable(
                name: "Units",
                oldComment: "Measuring units");

            migrationBuilder.AlterTable(
                name: "Transfers",
                oldComment: "Transfer Data");

            migrationBuilder.AlterTable(
                name: "TransferDetails",
                oldComment: "Deatails for the Transfers");

            migrationBuilder.AlterTable(
                name: "Stores",
                oldComment: "Store Data");

            migrationBuilder.AlterTable(
                name: "Sells",
                oldComment: "Data for a Sell");

            migrationBuilder.AlterTable(
                name: "SellDetails",
                oldComment: "Deatails for the Sells");

            migrationBuilder.AlterTable(
                name: "PartidesInStores",
                oldComment: "Partides quantity in the stores");

            migrationBuilder.AlterTable(
                name: "DeliveryDetails",
                oldComment: "Deatails for the Delivery");

            migrationBuilder.AlterTable(
                name: "Deliveries",
                oldComment: "Data for a Delivery");

            migrationBuilder.AlterTable(
                name: "Countries",
                oldComment: "Data for a Country");

            migrationBuilder.AlterTable(
                name: "Contragents",
                oldComment: "Data for a Contragent (Client or Supplier)");

            migrationBuilder.AlterTable(
                name: "Cities",
                oldComment: "Data for a City");

            migrationBuilder.AlterTable(
                name: "Articles",
                oldComment: "Data for a Article");

            migrationBuilder.AlterTable(
                name: "Addresses",
                oldComment: "Data for a Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldComment: "Unit Short Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Units",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use Units");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Units",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Unit Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Units",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unit Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ToStoreId",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Tarnsfer destination store Identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Transfers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use");

            migrationBuilder.AlterColumn<Guid>(
                name: "FromStoreId",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Tarnsfer source store Identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Tarnsfer Date of creation");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Transfers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Tarnsfer Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransferId",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Parent Tarnsfer Identifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "TransferDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Transfered Quantity");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "TransferDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Delivery Detail Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TransferDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Tarnsfer Detail Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "Store Name");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stores",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use Store");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Stores",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "Store Description");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Address Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Store Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Store Identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Sells",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Sells",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "DateTime of creation");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Contargent (Client) Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sells",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Sell Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unit Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Store Sell Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Parent Sell Identifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "SellDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Quantity to sell");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "SellDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Sell price");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "SellDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "DeliveryDetail Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SellDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Sell Detail Identifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "PartidesInStores",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDetailId",
                table: "PartidesInStores",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "DeliveryDetail (Partide) Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "PartidesInStores",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Store Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unit Identifier");

            migrationBuilder.AlterColumn<double>(
                name: "Qty",
                table: "DeliveryDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Delivered Quantity");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "DeliveryDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Delivered Price");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DeliveryDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Parent Delivery Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArticleId",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Article Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DeliveryDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Delivery Detail Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Store Identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsConfirmed",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for confermrd sell ");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDatetime",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "DateTime of creation");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Contargent (Supplier) Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Deliveries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Delivery Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "Name of Country");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEu",
                table: "Countries",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for EU countries");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Countries",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldComment: "Code of Country");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Countries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Country Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "Contragents",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16,
                oldComment: "Vat Number of Contragent (EGN when private person)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contragents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "Last Name of Contragent");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSupplier",
                table: "Contragents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag is the contragent can be supplier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsClient",
                table: "Contragents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag is the contragent can be client");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Contragents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contragents",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "First Name of Contragent");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contragents",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Contragent Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "Name of City");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Cities",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Country Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "City Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "Last Name of ApplicationUser");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "First Name of ApplicationUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "UnitId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Unit Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "Title of Article");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "Name of Article");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Articles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldComment: "Model of Article");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Articles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true,
                oldComment: "Description of Article");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryNumber",
                table: "Articles",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "Delivery Number of Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Article Identifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Flag for deleted/in use ");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Country Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContragentId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Contragent Identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "City Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Addresses",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126,
                oldComment: "Address Line 2 of Article");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                table: "Addresses",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126,
                oldComment: "Address Line 1 of Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Address Identifier");
        }
    }
}
