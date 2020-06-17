using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class imageforhelperandcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "71c49f24-a236-41de-b424-505e4358eba6", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c49f24-a236-41de-b424-505e4358eba6");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Images",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "d72e740b-659e-4645-b907-f0608e5435ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0a8d522b-41ce-4158-9955-cb8a70930e45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2e34bf26-2d97-4836-8f16-a19ba9bc0028");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "b860c63e-9efd-49e3-932c-596f030ecb12");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a4d0d9be-1bab-4ddb-88e7-edfa0943ff19", 0, "8e5e3429-71af-402a-b622-52e1528fa9a8", null, new DateTime(2020, 6, 17, 14, 30, 35, 139, DateTimeKind.Utc).AddTicks(3289), null, new DateTime(2020, 6, 17, 14, 30, 35, 139, DateTimeKind.Utc).AddTicks(3870), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEG0LONUNWZ+LYtVmlz+mTMA2Xw1StHjQt2tXsEgl8atDamsm4JcYQBXVIrpZNTYm3Q==", "123456789", false, (byte)1, "8dd3b551-9dcb-4615-923d-d0602b4b5eba", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(2706), new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(3582) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(6423), new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(6433) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(6513), new DateTime(2020, 6, 17, 14, 30, 35, 168, DateTimeKind.Utc).AddTicks(6515) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a4d0d9be-1bab-4ddb-88e7-edfa0943ff19", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CustomerId",
                table: "Images",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HelperId",
                table: "Images",
                column: "HelperId",
                unique: true,
                filter: "[HelperId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Customers_CustomerId",
                table: "Images",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Helpers_HelperId",
                table: "Images",
                column: "HelperId",
                principalTable: "Helpers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Customers_CustomerId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Helpers_HelperId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CustomerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_HelperId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a4d0d9be-1bab-4ddb-88e7-edfa0943ff19", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4d0d9be-1bab-4ddb-88e7-edfa0943ff19");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Images");

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
        }
    }
}
