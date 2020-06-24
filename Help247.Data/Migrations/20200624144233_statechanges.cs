using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class statechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8229a2-c1d5-45ca-a424-b67df5961e9a");

            migrationBuilder.DropColumn(
                name: "CountrId",
                table: "States");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "States",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b74faea1-994f-4c4f-9d97-150ee93d8204");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8499245d-f578-4098-b081-2052656dad7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "9e15bf2e-5a8c-4f46-ba89-505f10963aea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "6291c920-0478-4e19-9dcc-beb114eb2723");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ad22d965-c899-4df9-863e-7b18b1f8db2d", 0, "09a62afb-0001-401d-8035-3782e1bb25d7", null, new DateTime(2020, 6, 24, 14, 42, 32, 612, DateTimeKind.Utc).AddTicks(3886), null, new DateTime(2020, 6, 24, 14, 42, 32, 612, DateTimeKind.Utc).AddTicks(4408), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELKQ7r9DOCdBoCkp8CCgl8SpiqhQuQDcj0NaY6r2xaThmLLorl4HJ3cPHNHUdrZOnQ==", "123456789", false, (byte)1, "c5bcdcf7-6295-4725-91c3-9521666504eb", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 42, 32, 635, DateTimeKind.Utc).AddTicks(8581), new DateTime(2020, 6, 24, 14, 42, 32, 635, DateTimeKind.Utc).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 42, 32, 636, DateTimeKind.Utc).AddTicks(979), new DateTime(2020, 6, 24, 14, 42, 32, 636, DateTimeKind.Utc).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 42, 32, 636, DateTimeKind.Utc).AddTicks(1038), new DateTime(2020, 6, 24, 14, 42, 32, 636, DateTimeKind.Utc).AddTicks(1039) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ad22d965-c899-4df9-863e-7b18b1f8db2d", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ad22d965-c899-4df9-863e-7b18b1f8db2d", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad22d965-c899-4df9-863e-7b18b1f8db2d");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "States");

            migrationBuilder.AddColumn<int>(
                name: "CountrId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cecd4361-6274-4948-868d-a9a4520df5d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d97b578d-1f41-4b74-89c8-b86286cee860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8b17d839-410e-47cd-9d3a-1ee16fb12af3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "d45d1d5b-ff90-4817-990f-ad4eafd2b739");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", 0, "e4672a6d-0a6d-4e52-ad74-f1a1923ae1fe", null, new DateTime(2020, 6, 24, 14, 36, 55, 102, DateTimeKind.Utc).AddTicks(7460), null, new DateTime(2020, 6, 24, 14, 36, 55, 102, DateTimeKind.Utc).AddTicks(7897), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAENdx2VGG2+LoV/YArHGD3+8VkFLBiUYVnWGE+ei79/ockxPIxWsHQwaPegeZXA4F1Q==", "123456789", false, (byte)1, "ed2828cd-4382-4e9d-932e-daebc4802514", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(1579), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3604), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3655), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3657) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", "4" });
        }
    }
}
