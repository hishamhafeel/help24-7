using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "017c1a76-32dc-460d-a1c7-ff395cf889a2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017c1a76-32dc-460d-a1c7-ff395cf889a2");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountrId = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    StateCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cecd4361-6274-4948-868d-a9a4520df5d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d97b578d-1f41-4b74-89c8-b86286cee860");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8b17d839-410e-47cd-9d3a-1ee16fb12af3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "d45d1d5b-ff90-4817-990f-ad4eafd2b739");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", 0, "e4672a6d-0a6d-4e52-ad74-f1a1923ae1fe", null, new DateTime(2020, 6, 24, 14, 36, 55, 102, DateTimeKind.Utc).AddTicks(7460), null, new DateTime(2020, 6, 24, 14, 36, 55, 102, DateTimeKind.Utc).AddTicks(7897), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAENdx2VGG2+LoV/YArHGD3+8VkFLBiUYVnWGE+ei79/ockxPIxWsHQwaPegeZXA4F1Q==", "123456789", false, (byte)1, "ed2828cd-4382-4e9d-932e-daebc4802514", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(1579), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3604), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3610) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3655), new DateTime(2020, 6, 24, 14, 36, 55, 144, DateTimeKind.Utc).AddTicks(3657) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", "4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ce8229a2-c1d5-45ca-a424-b67df5961e9a", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce8229a2-c1d5-45ca-a424-b67df5961e9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f5439e91-bc44-4c26-9452-8b93f46efb4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "acaa63a4-a49c-49e9-be99-8891b4a48789");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "fb01a076-a35c-45f4-8785-4d15b56cadeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "943b4d27-5126-4cc2-bf74-ec228e7b8503");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "017c1a76-32dc-460d-a1c7-ff395cf889a2", 0, "d6d2a1a6-9fb8-4db9-81a5-74312c78a9f7", null, new DateTime(2020, 6, 24, 13, 53, 55, 910, DateTimeKind.Utc).AddTicks(2804), null, new DateTime(2020, 6, 24, 13, 53, 55, 910, DateTimeKind.Utc).AddTicks(3621), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAELRyznK4e6ub7colnZHC0QT89ihZtqd///M5epvyWXeQhM/dYiAZJATuqxLwneAnXQ==", "123456789", false, (byte)1, "b74415d0-a7e5-4e33-b5ba-c65585186a25", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(3156), new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(6791), new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(6874), new DateTime(2020, 6, 24, 13, 53, 55, 949, DateTimeKind.Utc).AddTicks(6877) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "017c1a76-32dc-460d-a1c7-ff395cf889a2", "4" });
        }
    }
}
