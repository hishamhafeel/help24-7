using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class country2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d108818b-7b3f-4ac2-a93c-bd9557866113", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d108818b-7b3f-4ac2-a93c-bd9557866113");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Iso3 = table.Column<string>(nullable: true),
                    Iso2 = table.Column<string>(nullable: true),
                    PhoneCode = table.Column<string>(nullable: true),
                    Capital = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "017c1a76-32dc-460d-a1c7-ff395cf889a2", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017c1a76-32dc-460d-a1c7-ff395cf889a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "4e37e7eb-4798-4d3e-a549-1a956c646d2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1faca5df-a575-4473-b539-937b1e6639f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f6b8834b-2167-45b3-bccd-b32aa882be5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "5550531d-38ff-4382-8341-e57f0696241e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d108818b-7b3f-4ac2-a93c-bd9557866113", 0, "bd1d25cb-a9aa-43d9-ae18-6af4dae14382", null, new DateTime(2020, 6, 24, 13, 50, 51, 675, DateTimeKind.Utc).AddTicks(6405), null, new DateTime(2020, 6, 24, 13, 50, 51, 675, DateTimeKind.Utc).AddTicks(7046), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEPbrlS4xfe7NIrToKnrEBALu8AienIpt5Jh6f1gXoPsto0Z3AMF6ZTrxeftz2+lCAw==", "123456789", false, (byte)1, "1ce7710d-5766-4d39-9d1a-3755e6835c7c", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(5636), new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(6145) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(7954), new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(7961) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(8003), new DateTime(2020, 6, 24, 13, 50, 51, 697, DateTimeKind.Utc).AddTicks(8004) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d108818b-7b3f-4ac2-a93c-bd9557866113", "4" });
        }
    }
}
