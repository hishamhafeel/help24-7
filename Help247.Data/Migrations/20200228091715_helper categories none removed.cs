using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class helpercategoriesnoneremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8ffae757-ee58-45ec-aae8-a27407a694b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "ee902007-25a9-4ab1-8d3c-e172dff7f594");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "802b7964-078d-4b96-91bf-47ed54e0dff7");

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "CCTV Installation and Fixing", "Cctv" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Network Planning and Troubleshooting", "NetworkPlanning" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "PABX - Private Automatic Issues", "Pabx" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Cisco Routing - Service Maintenance", "Cisco" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "IT and other projects", "IT" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Office Relocation IT Setup", "OfficeRelocation" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Office New IT Setup", "OfficeNewSetup" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Basic Hardware Repairing", "HardwareRepair" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "af9d93b2-647a-4d4d-87d6-edba8c0d10a4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8d3a8f5d-41ed-40c7-9eec-b4514ddc1c58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "8cbbff90-dc4c-451a-8e31-897699955f02");

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Category not assigned", "None" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "CCTV Installation and Fixing", "Cctv" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Network Planning and Troubleshooting", "NetworkPlanning" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "PABX - Private Automatic Issues", "Pabx" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Cisco Routing - Service Maintenance", "Cisco" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "IT and other projects", "IT" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Office Relocation IT Setup", "OfficeRelocation" });

            migrationBuilder.UpdateData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryDescription", "CategoryName" },
                values: new object[] { "Office New IT Setup", "OfficeNewSetup" });

            migrationBuilder.InsertData(
                table: "HelperCategories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName" },
                values: new object[] { 9, "Basic Hardware Repairing", "HardwareRepair" });
        }
    }
}
