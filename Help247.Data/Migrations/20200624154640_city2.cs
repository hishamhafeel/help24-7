using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class city2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bf3c06ec-5f69-4624-8ce1-02bf2703e5a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "045d369b-e99b-4c66-8bcb-9238a867341e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "98818449-16c8-440b-9661-c687bc5bc28c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "7c8160ed-50a0-4d71-a485-e11b447e3c59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", 0, "1d7d42f2-af5d-44af-a84f-20061ee826bc", null, new DateTime(2020, 6, 24, 15, 46, 39, 228, DateTimeKind.Utc).AddTicks(383), null, new DateTime(2020, 6, 24, 15, 46, 39, 228, DateTimeKind.Utc).AddTicks(1133), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEIYhQap2dgrlvwh9Iv5iSuavN41LyfhkLu8nqCsP2aiyBKFZID5w8VMKDQ459BGlHA==", "123456789", false, (byte)1, "5c4ee837-b6cf-4666-a39e-da2db4166f79", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 251, DateTimeKind.Utc).AddTicks(9774), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2167), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2175) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2227), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2229) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d747c2e-a82a-4fa3-acf7-4e183a521568");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "50f027c1-011d-4bc9-a4b8-3d273de3e2b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fbc2c30b-e15e-4d9a-8175-067c0b831baf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "951faa52-0f7a-4e43-9156-eaff3b2c0f4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "6e06458d-45c8-453f-a2e6-a532b88e3097");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", 0, "1597a1b8-7780-4073-b329-81f38dc8dabc", null, new DateTime(2020, 6, 24, 15, 9, 27, 638, DateTimeKind.Utc).AddTicks(4447), null, new DateTime(2020, 6, 24, 15, 9, 27, 638, DateTimeKind.Utc).AddTicks(5204), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEI+7LuIAFFP81ZmoLOMCWEf7ZRTWMWJKe3gutHgqg+zOUpnwDGaM366MTZEqUlnk5w==", "123456789", false, (byte)1, "bb32ba19-8294-4ef7-8e57-3d6332e6b3f1", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(1164), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4847), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4929), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", "4" });
        }
    }
}
