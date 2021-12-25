using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_m_Universities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_Educations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<float>(type: "real", nullable: false),
                    UniversityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_m_Educations_Tb_m_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Tb_m_Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_Profilings",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_Profilings", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_m_Profilings_Tb_m_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Tb_m_Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_Accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_Accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_m_Accounts_Tb_m_Profilings_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_m_Profilings",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_m_Employees",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_m_Employees", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Tb_m_Employees_Tb_m_Accounts_NIK",
                        column: x => x.NIK,
                        principalTable: "Tb_m_Accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_m_Educations_UniversityId",
                table: "Tb_m_Educations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_m_Profilings_EducationId",
                table: "Tb_m_Profilings",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_m_Employees");

            migrationBuilder.DropTable(
                name: "Tb_m_Accounts");

            migrationBuilder.DropTable(
                name: "Tb_m_Profilings");

            migrationBuilder.DropTable(
                name: "Tb_m_Educations");

            migrationBuilder.DropTable(
                name: "Tb_m_Universities");
        }
    }
}
