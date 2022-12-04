using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class SeedUnitsCountriesArticlesAddressesContragentsStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1efc4197-6067-404f-8f6a-83f265237320",
                column: "ConcurrencyStamp",
                value: "79c8f7ca-0e9a-4498-b47d-093a56e4627c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bf8f04b-bc67-43ea-9924-001bf045b149",
                column: "ConcurrencyStamp",
                value: "c2e74bf7-0288-4845-81a5-4b6686803464");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64c7e2a2-f704-4515-a294-13fa5e9b28a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11114f63-c114-4c4d-8f53-e470c6d0024b", "AQAAAAEAACcQAAAAENRksJBe8ILbQB5cQvxyTUtxCwYbL6XBlM8HRXxkbvuf/rMFhUgXO83pYEC76s4JVQ==", "999ef65b-c247-4792-b56d-1521517b80d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07d05647-3731-48ff-b82c-a2b4366cf15a", "AQAAAAEAACcQAAAAEJDWnH1ETY4ONfdY77lbsArlFLVEqcLhx/PF2CdOmEN/lnvZWfu3jlEoXv2QzhZnJA==", "1c33a9ff-0340-41f1-bf75-0e45e34ea4bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81762cb3-03ed-415e-a81a-4b73c9fec1fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9d7c581-4819-4ce7-86ff-74f8c1a04c08", "AQAAAAEAACcQAAAAEJsmauS61rph446CK5Cby0Nq1y1vCQPXTlnyBGlKZ0fP2PXUM+K0ncB0go5dz0KSHw==", "207c5777-19be-4e93-ac1f-304adcaa6a58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5798b10-2d39-479f-9e29-042ed2562c3f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f88de7-a7b2-41cb-a8da-f13703024515", "AQAAAAEAACcQAAAAEFL6Q6G4Z5CI1HaTs3JHkA0+7rUt1+nXHvv1ZGhi9R+PaW06pQdkRR3+j/qY2Vj9MQ==", "7fbb349a-578e-4301-a65d-280a53355b23" });

            migrationBuilder.InsertData(
                table: "Contragents",
                columns: new[] { "Id", "FirstName", "IsActive", "IsClient", "IsSupplier", "LastName", "VatNumber" },
                values: new object[,]
                {
                    { new Guid("0625109a-585a-4c4e-be30-5a18b1e311f8"), "STC ltd.", true, true, true, "Smart Trusted Computers ltd.", "182681ER232" },
                    { new Guid("c85f94df-a849-42b7-a08b-e7ef758dfb43"), "Kassy", true, true, false, "Chandler", "8147822135" },
                    { new Guid("e9e67ae0-84c7-4279-96fc-bf12baaea7e9"), "Adrean", true, true, false, "Vasilev", "9273028735" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IsActive", "IsEu", "Name" },
                values: new object[,]
                {
                    { new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"), "US", true, false, "United States" },
                    { new Guid("418edfff-63b9-4275-9037-8702ca24085a"), "BG", true, true, "Bulgaria" },
                    { new Guid("afc087c9-1609-4834-b407-e64d47dfef63"), "DE", true, true, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("20b0aaca-9283-4486-be89-ed67e515c2e2"), "Meters", true, "m" },
                    { new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"), "Pieces", true, "pcs" },
                    { new Guid("b830df7a-9bba-44db-bf48-39b2f76881bd"), "Kilograms", true, "kg" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "DeliveryNumber", "Description", "IsActive", "Model", "Name", "Title", "UnitId" },
                values: new object[,]
                {
                    { new Guid("2d1c64fc-6628-4ddb-bcd5-164134f35934"), "RJ-45 - 21.99.1331", "Cable RJ-45 to RJ-45", true, "RJ-45", "Cable", "Cable RJ-45", new Guid("20b0aaca-9283-4486-be89-ed67e515c2e2") },
                    { new Guid("6f5d0558-9c9c-4082-84f2-be8bbce62532"), "DSY-MO140", "Mouse Disney Hanna Montana", true, "DSY-MO140", "Mouse", "USB mouse", new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6") },
                    { new Guid("f8227782-0e7f-4eac-bc87-d0b9ab145250"), "182681", "Black keyboard", true, "KC-200", "Keyboard", "USB keyboard", new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6") }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"), new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true, "Plovdiv" },
                    { new Guid("6402b8cf-af94-406a-878e-d89db204e082"), new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"), true, "New York" },
                    { new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"), new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true, "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "ContragentId", "CountryId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("0cf17f71-ad5c-461a-8a53-3c1c9616eea2"), "12 Blagovest Str.", "fl. 1", new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"), null, new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true },
                    { new Guid("171840b5-d316-4274-b4ae-4b7b611a8179"), "6 Gurko Str.", "fl. 1", new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"), null, new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true },
                    { new Guid("283c85c8-0113-48f3-b5c8-3187f9299bf8"), "1 Murgash Str.", "fl. 2; pl. 3", new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"), new Guid("e9e67ae0-84c7-4279-96fc-bf12baaea7e9"), new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true },
                    { new Guid("68042d85-077e-4383-9c0d-0ffbc3c4fd96"), "30 Peshtersko shose Blvd.", "fl. 3; pl. 7", new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"), new Guid("c85f94df-a849-42b7-a08b-e7ef758dfb43"), new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true },
                    { new Guid("bb884490-1ae1-4caf-a4ac-55bf6394bc9d"), "526 New Ave.", "Brooklyn, NY 11237", new Guid("6402b8cf-af94-406a-878e-d89db204e082"), new Guid("0625109a-585a-4c4e-be30-5a18b1e311f8"), new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"), true },
                    { new Guid("eeb8e279-8df5-4eac-b59c-d04e17639ece"), "14 Tzar Osvoboditel Blvd.", "fl. 1", new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"), null, new Guid("418edfff-63b9-4275-9037-8702ca24085a"), true }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("7c105c2a-e381-4586-9a3c-32a5aae96cc3"), new Guid("171840b5-d316-4274-b4ae-4b7b611a8179"), "Store for prepared articles to export", true, "Export Store" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("c4628027-2999-43b9-9ec4-0fe9df4d3ff2"), new Guid("eeb8e279-8df5-4eac-b59c-d04e17639ece"), "Central store for incoming articles", true, "Central Store." });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("e9cbf847-aa4c-4591-b31e-3f7d39ae6389"), new Guid("0cf17f71-ad5c-461a-8a53-3c1c9616eea2"), "Central store for Plovdiv", true, "Plovdiv Store" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("283c85c8-0113-48f3-b5c8-3187f9299bf8"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("68042d85-077e-4383-9c0d-0ffbc3c4fd96"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("bb884490-1ae1-4caf-a4ac-55bf6394bc9d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2d1c64fc-6628-4ddb-bcd5-164134f35934"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6f5d0558-9c9c-4082-84f2-be8bbce62532"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f8227782-0e7f-4eac-bc87-d0b9ab145250"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("afc087c9-1609-4834-b407-e64d47dfef63"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("7c105c2a-e381-4586-9a3c-32a5aae96cc3"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("c4628027-2999-43b9-9ec4-0fe9df4d3ff2"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("e9cbf847-aa4c-4591-b31e-3f7d39ae6389"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("b830df7a-9bba-44db-bf48-39b2f76881bd"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0cf17f71-ad5c-461a-8a53-3c1c9616eea2"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("171840b5-d316-4274-b4ae-4b7b611a8179"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("eeb8e279-8df5-4eac-b59c-d04e17639ece"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6402b8cf-af94-406a-878e-d89db204e082"));

            migrationBuilder.DeleteData(
                table: "Contragents",
                keyColumn: "Id",
                keyValue: new Guid("0625109a-585a-4c4e-be30-5a18b1e311f8"));

            migrationBuilder.DeleteData(
                table: "Contragents",
                keyColumn: "Id",
                keyValue: new Guid("c85f94df-a849-42b7-a08b-e7ef758dfb43"));

            migrationBuilder.DeleteData(
                table: "Contragents",
                keyColumn: "Id",
                keyValue: new Guid("e9e67ae0-84c7-4279-96fc-bf12baaea7e9"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("20b0aaca-9283-4486-be89-ed67e515c2e2"));

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5d1c80b6-b785-4676-8b82-ac7fd4015b5e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c0eef3b2-d651-41dc-9525-e1e77d82df54"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("30ec83ae-2c10-41ea-999f-78f3d2c0fe2a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("418edfff-63b9-4275-9037-8702ca24085a"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1efc4197-6067-404f-8f6a-83f265237320",
                column: "ConcurrencyStamp",
                value: "7171b849-e528-44ab-88c9-88d1f8a437db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bf8f04b-bc67-43ea-9924-001bf045b149",
                column: "ConcurrencyStamp",
                value: "83abf491-bb21-40a2-8e5b-b17b44f3da54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64c7e2a2-f704-4515-a294-13fa5e9b28a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8685428e-a03b-4186-8e15-c782274dc198", "AQAAAAEAACcQAAAAEP2Sv7bdb7YYZeJUDfbcBSwfOJBirAT8MltyoMFSnebQyyNDYqhdWydcAcfF4m3KUA==", "ac882fce-8620-4772-a64f-06d2f04fdc62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afd84f8b-1995-4631-aa2b-da103025cfd7", "AQAAAAEAACcQAAAAEEF0TBRj9VkwJ5ss0SHRHn14ohBq39wAr8L/ylg76E7q4TknTF2GVG49eRu9jDiUlA==", "a4b27cfa-236b-4fd8-8e2c-5a88b830830f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81762cb3-03ed-415e-a81a-4b73c9fec1fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee66e2f6-821b-4613-9549-f521790b277f", "AQAAAAEAACcQAAAAEF1qcXoEwSitcE7Nd7obOoXRiOk3pgwJC1+dzlScjsr8oGF+jzjLYNZ1lV8J2PgOFg==", "988c79da-d331-4c0d-b3bf-7fc9202f39fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5798b10-2d39-479f-9e29-042ed2562c3f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51510224-e2e0-45ab-9e6b-917732f95840", "AQAAAAEAACcQAAAAECB6SaVd56gjM0ZocGxJvksEJ1nTQ6T6APyJRnHid89I0pw6Da00xcKTSoLYxEfcQg==", "27deb7ff-9ac0-4558-a6fb-f9ab646d414b" });
        }
    }
}
