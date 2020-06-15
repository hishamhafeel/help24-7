using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Ticketentityupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f34dadaa-8fa1-48a9-a148-fc6dda5294c5", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f34dadaa-8fa1-48a9-a148-fc6dda5294c5");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HelpTime",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tickets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "c36f6347-1ea6-4dc2-be20-c717969cf586");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "196f5ac8-90d5-4544-9dde-d5f20d6bf177");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "7f0b1bb1-c410-4a2a-b85f-2f3535326f1a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "96b897f8-2f55-4570-9e7a-b4e8ff18b1c8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ecd2125a-8c4d-439d-b332-0bd99a75724d", 0, "bbacacf0-a80d-45ab-9aff-1c25b9d41f14", null, new DateTime(2020, 6, 11, 15, 39, 18, 836, DateTimeKind.Utc).AddTicks(1073), null, new DateTime(2020, 6, 11, 15, 39, 18, 836, DateTimeKind.Utc).AddTicks(2026), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBFIhvZuJALoBqEH5R0xUFQWTIvUUzCUWAE+gHxTdz3+GXdmdRI8eyc2zaZBkpFnyA==", "123456789", false, (byte)1, "142ebc10-23ce-4299-85f1-df73959d4469", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(4628), new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(6779), new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(6830), new DateTime(2020, 6, 11, 15, 39, 18, 864, DateTimeKind.Utc).AddTicks(6831) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ecd2125a-8c4d-439d-b332-0bd99a75724d", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ecd2125a-8c4d-439d-b332-0bd99a75724d", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecd2125a-8c4d-439d-b332-0bd99a75724d");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "HelpTime",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9ceac298-4cd8-4d1f-9a80-d9b5d3da834d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b395d023-8fff-4ecd-8aab-3817a3b68939");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "94a560f1-b6b1-4955-95eb-c1b4a550f50d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "4cf7cadd-c573-47b4-aecb-ee0fe2bed3ed");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f34dadaa-8fa1-48a9-a148-fc6dda5294c5", 0, "be5ab070-277e-4f2f-82c8-ab9ad450163a", null, new DateTime(2020, 6, 11, 5, 19, 49, 606, DateTimeKind.Utc).AddTicks(6713), null, new DateTime(2020, 6, 11, 5, 19, 49, 606, DateTimeKind.Utc).AddTicks(7191), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEHJPDbmEY6vrbf37fSueIeRkJTtiCXK03Hzt2HDEuXMpXl0AL3iKc3iP4NWsSnkqTQ==", "123456789", false, (byte)1, "24066966-a258-412a-b2f3-5597f1d5bbfb", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(7694), new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(8223) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(9745), new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(9796), new DateTime(2020, 6, 11, 5, 19, 49, 627, DateTimeKind.Utc).AddTicks(9797) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f34dadaa-8fa1-48a9-a148-fc6dda5294c5", "4" });
        }
    }
}
