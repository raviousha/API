using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changevariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Tb_m_Employees",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Tb_m_Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Tb_m_Employees",
                newName: "gender");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Tb_m_Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
