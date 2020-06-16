using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class Feedback_adding_Ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "08ae07b7-f766-4950-ae48-16f3e60fc2ab", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08ae07b7-f766-4950-ae48-16f3e60fc2ab");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Feedbacks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "627f8881-102f-48c0-b4e0-a22c28ff9d56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b8fd02d4-cc7f-408a-8155-e5669edbaa43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2eefed3f-e4d8-42a6-8ec0-cbaebb2c1a49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "63be8d41-fc66-463f-8143-dbe4bc58d2f0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "71c49f24-a236-41de-b424-505e4358eba6", 0, "b99465be-3ef1-422a-9784-46680a0d98bd", null, new DateTime(2020, 6, 16, 11, 29, 24, 987, DateTimeKind.Utc).AddTicks(8863), null, new DateTime(2020, 6, 16, 11, 29, 24, 987, DateTimeKind.Utc).AddTicks(9907), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEHj9n1H0U6vZo3dINy+pZ9YRUIJt0UQ4lHxRcZlTop1VWHaGDTRoZfVwVRfKxnCphQ==", "123456789", false, (byte)1, "1069f78f-2b2b-4e42-af5b-f77dbdeaeb94", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 16, 11, 29, 25, 24, DateTimeKind.Utc).AddTicks(4394), new DateTime(2020, 6, 16, 11, 29, 25, 24, DateTimeKind.Utc).AddTicks(5752) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 16, 11, 29, 25, 25, DateTimeKind.Utc).AddTicks(624), new DateTime(2020, 6, 16, 11, 29, 25, 25, DateTimeKind.Utc).AddTicks(634) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 16, 11, 29, 25, 25, DateTimeKind.Utc).AddTicks(695), new DateTime(2020, 6, 16, 11, 29, 25, 25, DateTimeKind.Utc).AddTicks(696) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "71c49f24-a236-41de-b424-505e4358eba6", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_TicketId",
                table: "Feedbacks",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Tickets_TicketId",
                table: "Feedbacks",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Tickets_TicketId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_TicketId",
                table: "Feedbacks");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "71c49f24-a236-41de-b424-505e4358eba6", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c49f24-a236-41de-b424-505e4358eba6");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Feedbacks");

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
    }
}
