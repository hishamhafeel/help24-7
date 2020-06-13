using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Ticketupdatesfurther : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ecd2125a-8c4d-439d-b332-0bd99a75724d", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecd2125a-8c4d-439d-b332-0bd99a75724d");

            migrationBuilder.AddColumn<int>(
                name: "HelperId",
                table: "Images",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3875d5b5-56c4-459f-a1af-a04806131979", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3875d5b5-56c4-459f-a1af-a04806131979");

            migrationBuilder.DropColumn(
                name: "HelperId",
                table: "Images");

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
    }
}
