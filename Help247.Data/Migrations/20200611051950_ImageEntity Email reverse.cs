using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class ImageEntityEmailreverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "239218d9-8a3f-4725-ba9d-d47fd242d5bf", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "239218d9-8a3f-4725-ba9d-d47fd242d5bf");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f34dadaa-8fa1-48a9-a148-fc6dda5294c5", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f34dadaa-8fa1-48a9-a148-fc6dda5294c5");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "99699754-c2a6-49e2-be31-7a9df1066b12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "50b57674-e172-4236-b37c-10226b097e22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "41edc8e9-79ea-4a43-a382-b1393237549e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "8c34e723-57b0-41b9-9456-284ba3f5577b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "239218d9-8a3f-4725-ba9d-d47fd242d5bf", 0, "d961c800-5734-42a0-9ab8-e833362bed2e", null, new DateTime(2020, 6, 11, 4, 57, 54, 408, DateTimeKind.Utc).AddTicks(1055), null, new DateTime(2020, 6, 11, 4, 57, 54, 408, DateTimeKind.Utc).AddTicks(1565), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEOVCquiq/0yg47YY8//xyHmOu5ExBFZ67hLsa6w9r0wl8u8WRyKapdL3SXfx2SWUVw==", "123456789", false, (byte)1, "1bd8ce4e-b086-42ac-84c8-7cd45a088fdd", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 57, 54, 434, DateTimeKind.Utc).AddTicks(7805), new DateTime(2020, 6, 11, 4, 57, 54, 434, DateTimeKind.Utc).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 57, 54, 435, DateTimeKind.Utc).AddTicks(1095), new DateTime(2020, 6, 11, 4, 57, 54, 435, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 11, 4, 57, 54, 435, DateTimeKind.Utc).AddTicks(1158), new DateTime(2020, 6, 11, 4, 57, 54, 435, DateTimeKind.Utc).AddTicks(1160) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "239218d9-8a3f-4725-ba9d-d47fd242d5bf", "4" });
        }
    }
}
