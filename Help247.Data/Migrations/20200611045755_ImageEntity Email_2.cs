using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class ImageEntityEmail_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_ImageUrl",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "22167720-a6fe-4514-b362-cd4055f2b332", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22167720-a6fe-4514-b362-cd4055f2b332");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageUrl",
                table: "Images",
                column: "ImageUrl",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_ImageUrl",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "239218d9-8a3f-4725-ba9d-d47fd242d5bf", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "239218d9-8a3f-4725-ba9d-d47fd242d5bf");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

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

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageUrl",
                table: "Images",
                column: "ImageUrl",
                unique: true,
                filter: "[ImageUrl] IS NOT NULL");
        }
    }
}
