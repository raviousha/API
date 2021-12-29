using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changeARtablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Role_RolesId",
                table: "AccountRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRole_Tb_m_Accounts_AccountsNIK",
                table: "AccountRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Tb_m_Roles");

            migrationBuilder.RenameTable(
                name: "AccountRole",
                newName: "Tb_tr_AccountRoles");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRole_RolesId",
                table: "Tb_tr_AccountRoles",
                newName: "IX_Tb_tr_AccountRoles_RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRole_AccountsNIK",
                table: "Tb_tr_AccountRoles",
                newName: "IX_Tb_tr_AccountRoles_AccountsNIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_m_Roles",
                table: "Tb_m_Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_tr_AccountRoles",
                table: "Tb_tr_AccountRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_tr_AccountRoles_Tb_m_Accounts_AccountsNIK",
                table: "Tb_tr_AccountRoles",
                column: "AccountsNIK",
                principalTable: "Tb_m_Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_tr_AccountRoles_Tb_m_Roles_RolesId",
                table: "Tb_tr_AccountRoles",
                column: "RolesId",
                principalTable: "Tb_m_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_tr_AccountRoles_Tb_m_Accounts_AccountsNIK",
                table: "Tb_tr_AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_tr_AccountRoles_Tb_m_Roles_RolesId",
                table: "Tb_tr_AccountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_tr_AccountRoles",
                table: "Tb_tr_AccountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_m_Roles",
                table: "Tb_m_Roles");

            migrationBuilder.RenameTable(
                name: "Tb_tr_AccountRoles",
                newName: "AccountRole");

            migrationBuilder.RenameTable(
                name: "Tb_m_Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_tr_AccountRoles_RolesId",
                table: "AccountRole",
                newName: "IX_AccountRole_RolesId");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_tr_AccountRoles_AccountsNIK",
                table: "AccountRole",
                newName: "IX_AccountRole_AccountsNIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRole",
                table: "AccountRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Role_RolesId",
                table: "AccountRole",
                column: "RolesId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRole_Tb_m_Accounts_AccountsNIK",
                table: "AccountRole",
                column: "AccountsNIK",
                principalTable: "Tb_m_Accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
