using Microsoft.EntityFrameworkCore.Migrations;

namespace Help247.Data.Migrations
{
    public partial class seedhelpercategorydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "HelperCategories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category not assigned", "None" },
                    { 2, "CCTV Installation and Fixing", "Cctv" },
                    { 3, "Network Planning and Troubleshooting", "NetworkPlanning" },
                    { 4, "PABX - Private Automatic Issues", "Pabx" },
                    { 5, "Cisco Routing - Service Maintenance", "Cisco" },
                    { 6, "IT and other projects", "IT" },
                    { 7, "Office Relocation IT Setup", "OfficeRelocation" },
                    { 8, "Office New IT Setup", "OfficeNewSetup" },
                    { 9, "Basic Hardware Repairing", "HardwareRepair" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HelperCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f4bfed01-e51e-4e09-80d9-bd689d6f1889");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7081d23d-3a63-443e-8070-3d663cdc2288");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a3b62ab1-a47a-42e8-97f3-d87cbf26f638");
        }
    }
}
