using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e7f36e9-c05a-4600-b2d9-f4e95d2ee7de");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SateId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "50f027c1-011d-4bc9-a4b8-3d273de3e2b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fbc2c30b-e15e-4d9a-8175-067c0b831baf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "951faa52-0f7a-4e43-9156-eaff3b2c0f4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "6e06458d-45c8-453f-a2e6-a532b88e3097");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", 0, "1597a1b8-7780-4073-b329-81f38dc8dabc", null, new DateTime(2020, 6, 24, 15, 9, 27, 638, DateTimeKind.Utc).AddTicks(4447), null, new DateTime(2020, 6, 24, 15, 9, 27, 638, DateTimeKind.Utc).AddTicks(5204), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEI+7LuIAFFP81ZmoLOMCWEf7ZRTWMWJKe3gutHgqg+zOUpnwDGaM366MTZEqUlnk5w==", "123456789", false, (byte)1, "bb32ba19-8294-4ef7-8e57-3d6332e6b3f1", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(1164), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(1990) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4847), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4929), new DateTime(2020, 6, 24, 15, 9, 27, 674, DateTimeKind.Utc).AddTicks(4931) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fc0e62e-3f2d-43e4-80b4-0d7d2b5cd4bb");

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
    }
}
