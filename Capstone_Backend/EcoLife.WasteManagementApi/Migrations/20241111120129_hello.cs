using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoLife.WasteManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteManagementEntities",
                table: "WasteManagementEntities");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WasteManagementEntities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "WateManagementId",
                table: "WasteManagementEntities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteManagementEntities",
                table: "WasteManagementEntities",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WasteManagementEntities",
                table: "WasteManagementEntities");

            migrationBuilder.AlterColumn<int>(
                name: "WateManagementId",
                table: "WasteManagementEntities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WasteManagementEntities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WasteManagementEntities",
                table: "WasteManagementEntities",
                column: "WateManagementId");
        }
    }
}
