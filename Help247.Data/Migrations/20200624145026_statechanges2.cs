using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class statechanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "StateCode",
                table: "States");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2f598fe2-c669-43fd-bca5-aa3159f175eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a0d292d4-13bc-4fcd-9016-204767bccac9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2816ada7-efd7-47e7-be0b-ace1329d36da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "7a315750-34ba-4d35-bf36-bcff377c6d86");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ef1e576a-5b17-439c-b8b3-5553819289a2", 0, "1cfb14a9-b48f-47a7-8de2-688af130865c", null, new DateTime(2020, 6, 24, 14, 50, 25, 159, DateTimeKind.Utc).AddTicks(9373), null, new DateTime(2020, 6, 24, 14, 50, 25, 159, DateTimeKind.Utc).AddTicks(9875), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEH85q7v4TTodPOOjiyqZwKfquVFnx8m+/stA86TZWV2avO/e660Qri5l3/MqIsp69A==", "123456789", false, (byte)1, "04cb8fab-c940-45a8-b838-b978f2eb12fc", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(1165), new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(2011) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(4899), new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(4910) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(4983), new DateTime(2020, 6, 24, 14, 50, 25, 193, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ef1e576a-5b17-439c-b8b3-5553819289a2", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ef1e576a-5b17-439c-b8b3-5553819289a2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef1e576a-5b17-439c-b8b3-5553819289a2");

            migrationBuilder.AddColumn<string>(
                name: "StateCode",
                table: "States",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
