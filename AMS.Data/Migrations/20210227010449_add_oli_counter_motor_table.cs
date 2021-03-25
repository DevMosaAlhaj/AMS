using Microsoft.EntityFrameworkCore.Migrations;

namespace AMS.Data.Migrations
{
    public partial class add_oli_counter_motor_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OliCounter",
                table: "Motor",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OliCounter",
                table: "Motor");
        }
    }
}
