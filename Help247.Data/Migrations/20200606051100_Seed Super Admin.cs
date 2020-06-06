using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class SeedSuperAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000000", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000000");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "8cfe2362-b7ee-4843-8ec4-9766842b2f04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fa8e640d-b72c-44f6-b0ec-1946c8c78762");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "931bc0ff-0a1a-4a71-8452-ebec7cc9f8c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "13dc3874-7a5f-40a6-8d7b-5e4d976a1295");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", 0, "5f8a7662-193c-44aa-92ca-9769dc25293c", null, new DateTime(2020, 6, 6, 5, 6, 20, 259, DateTimeKind.Utc).AddTicks(8302), null, new DateTime(2020, 6, 6, 5, 6, 20, 259, DateTimeKind.Utc).AddTicks(8798), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEHuLd15nIfeKMfq/MYbqtiHi5ghPHWtz/CtsUO91C7+Yr5QUSC8OTyi2vMXqMhIZRQ==", "123456789", false, (byte)1, "e0946a5f-5b62-455a-a447-abc040cdc388", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(4055), new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(4629) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(6268), new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(6273) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(6316), new DateTime(2020, 6, 6, 5, 6, 20, 286, DateTimeKind.Utc).AddTicks(6317) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "00000000-0000-0000-0000-000000000000", "4" });
        }
    }
}
