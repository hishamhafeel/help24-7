using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class statechanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ef1e576a-5b17-439c-b8b3-5553819289a2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef1e576a-5b17-439c-b8b3-5553819289a2");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "28d171bc-0abd-4c5a-ad82-64ce3c1c2ba5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1a222308-eded-4568-b3bd-5790d0ae9e13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "22c5d733-fea7-4959-baa4-b48210450e6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "be321ae9-f075-4fc7-870d-2adcfba42d68");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de", 0, "8eb0c448-cbf6-459d-9606-948c05302dda", null, new DateTime(2020, 6, 24, 14, 59, 16, 504, DateTimeKind.Utc).AddTicks(7026), null, new DateTime(2020, 6, 24, 14, 59, 16, 504, DateTimeKind.Utc).AddTicks(7706), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEJqet/5pgkbGclPZhv9FIPzz+2htAFeO4i1BL/SxF+TL3wRSsdkb5ocdC1VDk1YfeA==", "123456789", false, (byte)1, "55805998-1c59-4d62-90e2-da4cff8ab36f", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(1491), new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(2309) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(4869), new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(4878) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(4951), new DateTime(2020, 6, 24, 14, 59, 16, 540, DateTimeKind.Utc).AddTicks(4954) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
