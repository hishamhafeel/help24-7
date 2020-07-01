using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0590a96b-df02-43a9-a51d-4565e303a720", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0590a96b-df02-43a9-a51d-4565e303a720");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d108818b-7b3f-4ac2-a93c-bd9557866113", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d108818b-7b3f-4ac2-a93c-bd9557866113");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6504dda1-6d95-4510-af69-d7631700fe7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "951c9635-45fa-471f-a3a5-de5b6f4bf5be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f73f1404-7159-460c-8e45-72c1aa6b07f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "80ee341e-1b19-4d28-b6fc-6c49234ea60d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0590a96b-df02-43a9-a51d-4565e303a720", 0, "067d0bef-9ac3-447d-bcdf-313e3307f698", null, new DateTime(2020, 6, 23, 18, 49, 17, 856, DateTimeKind.Utc).AddTicks(4977), null, new DateTime(2020, 6, 23, 18, 49, 17, 856, DateTimeKind.Utc).AddTicks(5871), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEFUytezM9rIwc8eJU+Vs7nixFXMOA6WHdwcfOKBNVlzvuZ7bDQpye3gxaTH9qaVHJQ==", "123456789", false, (byte)1, "3bd5423c-e3f2-4039-b465-200aa1e4abbc", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(4188), new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(4984) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(7971), new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(7982) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(8053), new DateTime(2020, 6, 23, 18, 49, 17, 909, DateTimeKind.Utc).AddTicks(8055) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0590a96b-df02-43a9-a51d-4565e303a720", "4" });
        }
    }
}
