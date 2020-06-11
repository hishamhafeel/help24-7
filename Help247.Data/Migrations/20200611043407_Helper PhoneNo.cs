using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class HelperPhoneNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Helpers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Helpers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers",
                column: "MobileNo",
                unique: true,
                filter: "[MobileNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers",
                column: "PhoneNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "78157ef5-8c7f-4c2f-a536-d23a45838dc7", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78157ef5-8c7f-4c2f-a536-d23a45838dc7");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNo",
                table: "Helpers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "Helpers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "de904d73-1fbc-45e5-8ff8-47a40940e77f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "45971ac1-d729-4cba-a7a6-e3a38c9626b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "1862eab7-01ee-45ca-90dc-1a1b2a7258fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "201f87c1-c6d7-493c-92ce-b87bb1eacca3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b", 0, "929dcadf-41fc-4d8a-bc91-41cbfb8012e4", null, new DateTime(2020, 6, 9, 16, 20, 22, 994, DateTimeKind.Utc).AddTicks(2477), null, new DateTime(2020, 6, 9, 16, 20, 22, 994, DateTimeKind.Utc).AddTicks(2943), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEJwbWVrBbhfAT+iVl1IjFnVfa3xdm5PVlDI+vMZkZTXzB00YPYJmDSgyHcmeomJ1PQ==", "123456789", false, (byte)1, "c07c7567-f8f9-42f4-8ba5-52833ee8c815", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 16, 20, 23, 15, DateTimeKind.Utc).AddTicks(8202), new DateTime(2020, 6, 9, 16, 20, 23, 15, DateTimeKind.Utc).AddTicks(8811) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 16, 20, 23, 16, DateTimeKind.Utc).AddTicks(663), new DateTime(2020, 6, 9, 16, 20, 23, 16, DateTimeKind.Utc).AddTicks(669) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 16, 20, 23, 16, DateTimeKind.Utc).AddTicks(723), new DateTime(2020, 6, 9, 16, 20, 23, 16, DateTimeKind.Utc).AddTicks(725) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_MobileNo",
                table: "Helpers",
                column: "MobileNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_PhoneNo",
                table: "Helpers",
                column: "PhoneNo",
                unique: true,
                filter: "[PhoneNo] IS NOT NULL");
        }
    }
}
