using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class change_profiling_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_m_Accounts_Tb_m_Profilings_NIK",
                table: "Tb_m_Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_m_Profilings_Tb_m_Educations_EducationId",
                table: "Tb_m_Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_m_Profilings",
                table: "Tb_m_Profilings");

            migrationBuilder.RenameTable(
                name: "Tb_m_Profilings",
                newName: "Tb_tr_Profilings");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_m_Profilings_EducationId",
                table: "Tb_tr_Profilings",
                newName: "IX_Tb_tr_Profilings_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_tr_Profilings",
                table: "Tb_tr_Profilings",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_m_Accounts_Tb_tr_Profilings_NIK",
                table: "Tb_m_Accounts",
                column: "NIK",
                principalTable: "Tb_tr_Profilings",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_tr_Profilings_Tb_m_Educations_EducationId",
                table: "Tb_tr_Profilings",
                column: "EducationId",
                principalTable: "Tb_m_Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_m_Accounts_Tb_tr_Profilings_NIK",
                table: "Tb_m_Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_tr_Profilings_Tb_m_Educations_EducationId",
                table: "Tb_tr_Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_tr_Profilings",
                table: "Tb_tr_Profilings");

            migrationBuilder.RenameTable(
                name: "Tb_tr_Profilings",
                newName: "Tb_m_Profilings");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_tr_Profilings_EducationId",
                table: "Tb_m_Profilings",
                newName: "IX_Tb_m_Profilings_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_m_Profilings",
                table: "Tb_m_Profilings",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_m_Accounts_Tb_m_Profilings_NIK",
                table: "Tb_m_Accounts",
                column: "NIK",
                principalTable: "Tb_m_Profilings",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_m_Profilings_Tb_m_Educations_EducationId",
                table: "Tb_m_Profilings",
                column: "EducationId",
                principalTable: "Tb_m_Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
