using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class ImageEntityEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "78157ef5-8c7f-4c2f-a536-d23a45838dc7", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78157ef5-8c7f-4c2f-a536-d23a45838dc7");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Images",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0e5ec167-3290-4948-b5d8-3c6ffeb40647");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b6d82b57-3a88-4f0c-afdb-24b6eeec41e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "896dd7f7-2c19-47bd-8d88-29c47ab3956f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "4d035d87-67ed-46fb-b34d-9fb4577d2320");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "22167720-a6fe-4514-b362-cd4055f2b332", 0, "dde94b07-e3ff-4981-9992-8f9f3031a9df", null, new DateTime(2020, 6, 11, 4, 48, 8, 334, DateTimeKind.Utc).AddTicks(6313), null, new DateTime(2020, 6, 11, 4, 48, 8, 334, DateTimeKind.Utc).AddTicks(6772), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEImUz1V0l1c+s/0IkWUnG/rckio0C6tWG5gtPQKUgWRC6c159+7GNnG8pWWcukS7IQ==", "123456789", false, (byte)1, "beb36710-d2ca-4fd5-a125-f0c1fba35d20", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(6302), new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(6833) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(8411), new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(8417) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(8468), new DateTime(2020, 6, 11, 4, 48, 8, 355, DateTimeKind.Utc).AddTicks(8469) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "22167720-a6fe-4514-b362-cd4055f2b332", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "22167720-a6fe-4514-b362-cd4055f2b332", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22167720-a6fe-4514-b362-cd4055f2b332");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d19fe0c5-c25f-4359-b265-79bb4cddd617");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "07fa7942-d06a-4088-8211-312d2d3c7742");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ccf0f475-682e-46c3-bf7d-3c88240184d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "18d17620-d99d-449a-98bf-798d2f10d236");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78157ef5-8c7f-4c2f-a536-d23a45838dc7", 0, "1cb9bdd3-3211-45f4-85fb-e0291acdf0c0", null, new DateTime(2020, 6, 11, 4, 34, 6, 219, DateTimeKind.Utc).AddTicks(8984), null, new DateTime(2020, 6, 11, 4, 34, 6, 219, DateTimeKind.Utc).AddTicks(9560), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEMLtB7hN6BJig4z54uNkgmBq/gryNkca2ZSiW5z2GkDsavvvJ0GXNThHHQ+/61110Q==", "123456789", false, (byte)1, "96c567ca-7658-48b4-b384-974101420284", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 34, 6, 247, DateTimeKind.Utc).AddTicks(7094), new DateTime(2020, 6, 11, 4, 34, 6, 247, DateTimeKind.Utc).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 34, 6, 248, DateTimeKind.Utc).AddTicks(625), new DateTime(2020, 6, 11, 4, 34, 6, 248, DateTimeKind.Utc).AddTicks(635) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 34, 6, 248, DateTimeKind.Utc).AddTicks(691), new DateTime(2020, 6, 11, 4, 34, 6, 248, DateTimeKind.Utc).AddTicks(692) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "78157ef5-8c7f-4c2f-a536-d23a45838dc7", "4" });
        }
    }
}
