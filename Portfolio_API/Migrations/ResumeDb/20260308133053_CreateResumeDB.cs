using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations.ResumeDb
{
    /// <inheritdoc />
    public partial class CreateResumeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    experience_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    company_name = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    started_at = table.Column<string>(type: "varchar(255)", nullable: true),
                    description = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experiences", x => x.experience_id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    duration = table.Column<string>(type: "varchar(255)", nullable: true),
                    description = table.Column<string>(type: "varchar(255)", nullable: true),
                    cover_img = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.project_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_experiences_experience_id",
                table: "experiences",
                column: "experience_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_project_id",
                table: "projects",
                column: "project_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
