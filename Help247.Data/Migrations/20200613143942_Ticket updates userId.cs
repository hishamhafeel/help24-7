using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class TicketupdatesuserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3875d5b5-56c4-459f-a1af-a04806131979", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3875d5b5-56c4-459f-a1af-a04806131979");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Helpers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cf9d1447-fe8d-45a1-93bc-dc7ab33edd63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "159fb6ba-76fd-4017-b98b-200a137644c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a12c1d66-a46d-4c7e-8268-657a0b65e689");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "fa42a1ef-b668-4958-92b5-6470d92634ae");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "08ae07b7-f766-4950-ae48-16f3e60fc2ab", 0, "83256ad7-ab1d-4d0f-9370-d1820ca0fff0", null, new DateTime(2020, 6, 13, 14, 39, 41, 477, DateTimeKind.Utc).AddTicks(9854), null, new DateTime(2020, 6, 13, 14, 39, 41, 478, DateTimeKind.Utc).AddTicks(735), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELU7zb4g1VAreBvoRuJEXCql9yiNDYKhwLRDnI8AqqkQ9CXq7/JDMdQXEkAVQH3t9A==", "123456789", false, (byte)1, "b27e2d74-4b07-4152-b762-55695e0cbd7a", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 39, 41, 520, DateTimeKind.Utc).AddTicks(5540), new DateTime(2020, 6, 13, 14, 39, 41, 520, DateTimeKind.Utc).AddTicks(7167) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 39, 41, 521, DateTimeKind.Utc).AddTicks(2277), new DateTime(2020, 6, 13, 14, 39, 41, 521, DateTimeKind.Utc).AddTicks(2294) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 39, 41, 521, DateTimeKind.Utc).AddTicks(2378), new DateTime(2020, 6, 13, 14, 39, 41, 521, DateTimeKind.Utc).AddTicks(2383) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "08ae07b7-f766-4950-ae48-16f3e60fc2ab", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08ae07b7-f766-4950-ae48-16f3e60fc2ab", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08ae07b7-f766-4950-ae48-16f3e60fc2ab");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9dd54fc2-3962-4f36-845b-e87eea7b84c2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "377c0ace-7072-467e-9208-50190d150be9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "99bcc2ee-0dc2-4ebe-a8be-b075a92af85a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "8e03809b-88c6-4ea9-9033-3fa54a5baedd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3875d5b5-56c4-459f-a1af-a04806131979", 0, "ffe82459-5d92-4662-9cc8-0ecea3e9e21c", null, new DateTime(2020, 6, 13, 14, 21, 50, 186, DateTimeKind.Utc).AddTicks(6822), null, new DateTime(2020, 6, 13, 14, 21, 50, 186, DateTimeKind.Utc).AddTicks(7614), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELY47KgCJulqFO9QckDD2K+Vy23vXrYlVXkQxUBSAUMEbsl8WgoaJzTxvM5klxw2Qw==", "123456789", false, (byte)1, "0bf1a5f4-54c1-44c3-979e-211f3678187b", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(4762), new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(5728) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(9097), new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(9105) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(9176), new DateTime(2020, 6, 13, 14, 21, 50, 232, DateTimeKind.Utc).AddTicks(9177) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3875d5b5-56c4-459f-a1af-a04806131979", "4" });
        }
    }
}
