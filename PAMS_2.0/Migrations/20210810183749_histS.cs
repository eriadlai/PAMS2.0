using Microsoft.EntityFrameworkCore.Migrations;

namespace PAMS_2._0.Migrations
{
    public partial class histS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "traumasInfo",
                table: "HistorialSexual",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "traumasInfo",
                table: "HistorialSexual");
        }
    }
}
