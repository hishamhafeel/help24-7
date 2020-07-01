using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class AddedTicketHasFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d747c2e-a82a-4fa3-acf7-4e183a521568");

            migrationBuilder.AddColumn<bool>(
                name: "HasFeedback",
                table: "Tickets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a3afe978-b0e6-4543-9f1e-557b269ee3da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "07a3cb19-1fe3-4e1e-87b2-cf6142d21ed4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a133de26-7c14-43c8-907b-40ed6a79d45c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "daf05141-14ea-4da3-8b69-21b1b53bec8f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "431fca8c-0fba-407e-846f-2248e7d139eb", 0, "934c3fc8-e3d3-46c5-88e1-af6fb14e3756", null, new DateTime(2020, 6, 27, 12, 46, 44, 413, DateTimeKind.Utc).AddTicks(8634), null, new DateTime(2020, 6, 27, 12, 46, 44, 413, DateTimeKind.Utc).AddTicks(9095), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBGzAxM/HIj0uA1RcmRq/9taMkbMmOIL1RiqhwyWaAozO+NSquZfdZYe0PHmqeK2XQ==", "123456789", false, (byte)1, "61642813-3cc8-4ad0-904b-b99bc3cf5425", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(3437), new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(5910), new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(5916) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(5963), new DateTime(2020, 6, 27, 12, 46, 44, 434, DateTimeKind.Utc).AddTicks(5964) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "431fca8c-0fba-407e-846f-2248e7d139eb", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "431fca8c-0fba-407e-846f-2248e7d139eb", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "431fca8c-0fba-407e-846f-2248e7d139eb");

            migrationBuilder.DropColumn(
                name: "HasFeedback",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bf3c06ec-5f69-4624-8ce1-02bf2703e5a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "045d369b-e99b-4c66-8bcb-9238a867341e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "98818449-16c8-440b-9661-c687bc5bc28c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "7c8160ed-50a0-4d71-a485-e11b447e3c59");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", 0, "1d7d42f2-af5d-44af-a84f-20061ee826bc", null, new DateTime(2020, 6, 24, 15, 46, 39, 228, DateTimeKind.Utc).AddTicks(383), null, new DateTime(2020, 6, 24, 15, 46, 39, 228, DateTimeKind.Utc).AddTicks(1133), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEIYhQap2dgrlvwh9Iv5iSuavN41LyfhkLu8nqCsP2aiyBKFZID5w8VMKDQ459BGlHA==", "123456789", false, (byte)1, "5c4ee837-b6cf-4666-a39e-da2db4166f79", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 251, DateTimeKind.Utc).AddTicks(9774), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2167), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2175) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2227), new DateTime(2020, 6, 24, 15, 46, 39, 252, DateTimeKind.Utc).AddTicks(2229) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8d747c2e-a82a-4fa3-acf7-4e183a521568", "4" });
        }
    }
}
