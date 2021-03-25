using Microsoft.EntityFrameworkCore.Migrations;

namespace AMS.Data.Migrations
{
    public partial class set_emp_id_not_null_user_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employee_ForEmpId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ForEmpId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employee_ForEmpId",
                table: "AspNetUsers",
                column: "ForEmpId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employee_ForEmpId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ForEmpId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employee_ForEmpId",
                table: "AspNetUsers",
                column: "ForEmpId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
