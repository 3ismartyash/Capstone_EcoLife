using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoLife.WasteManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class wastemanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WasteManagementEntities",
                columns: table => new
                {
                    WateManagementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecycledWaste = table.Column<double>(type: "float", nullable: false),
                    CompostWaste = table.Column<double>(type: "float", nullable: false),
                    LandfillWaste = table.Column<double>(type: "float", nullable: false),
                    RecordedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasteEmmision = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagementEntities", x => x.WateManagementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WasteManagementEntities");
        }
    }
}
