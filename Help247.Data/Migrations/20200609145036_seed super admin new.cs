using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class seedsuperadminnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "991b202e-172b-4bf4-ab8f-dbda8e288961", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "991b202e-172b-4bf4-ab8f-dbda8e288961");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "73c4b410-118b-40a2-8c08-ad21157af3e9", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73c4b410-118b-40a2-8c08-ad21157af3e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "e385b7df-8985-4798-8ec2-fc865af6767d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5e854527-0437-4132-9512-878d9010831a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "64fef136-44fc-4dee-b1d6-f25aa5e3dfce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "c3fada95-9d62-469e-a2f6-2f4a6db82fab");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "991b202e-172b-4bf4-ab8f-dbda8e288961", 0, "fde826d1-e413-4f38-8b5e-55553df06f85", null, new DateTime(2020, 6, 6, 5, 11, 0, 116, DateTimeKind.Utc).AddTicks(2385), null, new DateTime(2020, 6, 6, 5, 11, 0, 116, DateTimeKind.Utc).AddTicks(2890), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEGUdXe05gDvilcj0CWhki2PMMWPmxjR4yDHUc0CZS+wmefTMYehOKHDf6lUMlhzGNg==", "123456789", false, (byte)1, "2f910bb3-ddbb-4e95-84e5-db32513e7445", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(7536), new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(9725), new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(9732) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(9777), new DateTime(2020, 6, 6, 5, 11, 0, 143, DateTimeKind.Utc).AddTicks(9778) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "991b202e-172b-4bf4-ab8f-dbda8e288961", "4" });
        }
    }
}
