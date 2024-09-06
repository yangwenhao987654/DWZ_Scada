using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DWZ_Scada.Migrations
{
    /// <inheritdoc />
    public partial class addDatatbRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbRole",
                columns: new[] { "Id", "RoleName", "RoleType" },
                values: new object[,]
                {
                    { 1, "操作员", 1 },
                    { 2, "管理员", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbRole",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
