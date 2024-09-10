using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWZ_Scada.Migrations
{
    /// <inheritdoc />
    public partial class addAlarmtb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbDeviceAlarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlarmType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlarmInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AlarmDateStr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AlarmTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDeviceAlarm", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbDeviceAlarm");
        }
    }
}
