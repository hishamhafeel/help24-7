using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class imageIdinhelper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Helpers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "02de289b-d374-474f-a4dc-9f80dec3012b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ac1fe539-d652-49f7-91e8-96d7a5339698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "dd00065a-f95e-492b-900e-2c2787c9c8d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                column: "ConcurrencyStamp",
                value: "e670e87c-7723-44a2-811a-806bcb261c3e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedOn", "EditedById", "EditedOn", "Email", "EmailConfirmed", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecordState", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", 0, "fb76f00a-95d5-4c5b-90f3-a66e35eac5c5", null, new DateTime(2020, 6, 17, 15, 28, 32, 726, DateTimeKind.Utc).AddTicks(6781), null, new DateTime(2020, 6, 17, 15, 28, 32, 726, DateTimeKind.Utc).AddTicks(7876), "superadmin@admin.com", true, true, false, null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEMHJksENVlkj8sF/QhW6nbbhj99NXT9R+wjQbDpgByVSAzXirLpXuBRB7RMIx9W74A==", "123456789", false, (byte)1, "5ed0fd62-3b72-4b71-91df-d46633bf4a2a", false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 758, DateTimeKind.Utc).AddTicks(8529), new DateTime(2020, 6, 17, 15, 28, 32, 758, DateTimeKind.Utc).AddTicks(9332) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1894), new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1907) });

            migrationBuilder.UpdateData(
                table: "HelpCentres",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1984), new DateTime(2020, 6, 17, 15, 28, 32, 759, DateTimeKind.Utc).AddTicks(1986) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", "4" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CustomerId",
                table: "Images",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_ImageId",
                table: "Helpers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Helpers_Images_ImageId",
                table: "Helpers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helpers_Images_ImageId",
                table: "Helpers");

            migrationBuilder.DropIndex(
                name: "IX_Images_CustomerId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_ImageId",
                table: "Helpers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "dee7c787-b352-44f1-a1f1-8ca311d30ea6", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dee7c787-b352-44f1-a1f1-8ca311d30ea6");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Helpers");

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
                name: "FK_Images_Helpers_HelperId",
                table: "Images",
                column: "HelperId",
                principalTable: "Helpers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
