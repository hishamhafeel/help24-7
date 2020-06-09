using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class customerentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "73c4b410-118b-40a2-8c08-ad21157af3e9", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73c4b410-118b-40a2-8c08-ad21157af3e9");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c43f49ee-0e6c-4df1-bfcc-1c9bec38fe9b");

            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "24ecea2b-7ee7-4fdb-877f-6e872d69d09b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9f107912-1e4e-4236-b7de-6931f89a239f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a5d36324-24a9-41ca-acb1-189fe3817065");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "3a6f45dd-043e-4bd0-a6a9-ffb560abdedb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73c4b410-118b-40a2-8c08-ad21157af3e9", 0, "d5b4431b-556e-4539-b754-9f8007b38e9a", null, new DateTime(2020, 6, 9, 14, 50, 34, 789, DateTimeKind.Utc).AddTicks(8562), null, new DateTime(2020, 6, 9, 14, 50, 34, 789, DateTimeKind.Utc).AddTicks(9380), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELiaGo5S4Zl1QyWpV89c5zjlf5imzFffPFACrj9pfaMI7zxJCR4VEj56V2ecBHbPLQ==", "123456789", false, (byte)1, "3f75de6f-bfdb-416f-8897-8c40112d23e6", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 14, 50, 34, 814, DateTimeKind.Utc).AddTicks(9283), new DateTime(2020, 6, 9, 14, 50, 34, 815, DateTimeKind.Utc).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 14, 50, 34, 815, DateTimeKind.Utc).AddTicks(4514), new DateTime(2020, 6, 9, 14, 50, 34, 815, DateTimeKind.Utc).AddTicks(4522) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 9, 14, 50, 34, 815, DateTimeKind.Utc).AddTicks(4591), new DateTime(2020, 6, 9, 14, 50, 34, 815, DateTimeKind.Utc).AddTicks(4593) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "73c4b410-118b-40a2-8c08-ad21157af3e9", "4" });
        }
    }
}
