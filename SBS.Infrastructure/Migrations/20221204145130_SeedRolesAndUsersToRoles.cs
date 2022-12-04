using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBS.Infrastructure.Migrations
{
    public partial class SeedRolesAndUsersToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1efc4197-6067-404f-8f6a-83f265237320", "7171b849-e528-44ab-88c9-88d1f8a437db", "Admin", "ADMIN" },
                    { "73bf8f04b-bc67-43ea-9924-001bf045b149", "83abf491-bb21-40a2-8e5b-b17b44f3da54", "Manager", "MANAGER" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "73bf8f04b-bc67-43ea-9924-001bf045b149", "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1efc4197-6067-404f-8f6a-83f265237320", "81762cb3-03ed-415e-a81a-4b73c9fec1fb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "73bf8f04b-bc67-43ea-9924-001bf045b149", "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1efc4197-6067-404f-8f6a-83f265237320", "81762cb3-03ed-415e-a81a-4b73c9fec1fb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1efc4197-6067-404f-8f6a-83f265237320");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73bf8f04b-bc67-43ea-9924-001bf045b149");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64c7e2a2-f704-4515-a294-13fa5e9b28a8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0415ccc6-41af-458d-be4f-5b780a7386bb", "AQAAAAEAACcQAAAAEAzpt5pRFGsLAvUFxTKkbI0YvZWOTlmMziSIWFTMfiyoe0G8liAvRhYrtBkiTLffnw==", "7c0c3fb1-cae9-499f-b9c4-8db5a4512fad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "719a59a9-fc15-49be-a5e9-6f1d6f4fdc47",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ba6fc30-77e0-4ce0-b788-6bb49aece6d0", "AQAAAAEAACcQAAAAEOU8sUJLm2WoJJ7GIra7Q/Ocvyj/Xl04W75YboqIW/VG+35TtPcwAu+uOqpWmh85zA==", "118bc6ce-d61e-423d-84a5-353f5168a6ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81762cb3-03ed-415e-a81a-4b73c9fec1fb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cfb767a-6192-47c0-ba54-acedee4ee094", "AQAAAAEAACcQAAAAEN15C9XtD+NDZDDIRcuMWGfFZYNGdeQj6nOM5oFDN2c2daci8wsUb5I9+qglNL+zjA==", "530aeeec-99a0-4c8f-aa4c-91a8f4a4f762" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5798b10-2d39-479f-9e29-042ed2562c3f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc88d059-b4a7-4ede-8125-85579aeeae02", "AQAAAAEAACcQAAAAEEfa92qxajG9njt9xYOWjvlcrJU81wBtIOSBNukj3EcaAMTxERy2ixn5XNsUleNi8Q==", "a53d2605-9cd3-4dc0-825f-b4f46434028d" });
        }
    }
}
