using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    experience_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    finished_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    responsibility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__experien__EB216AFCF79CD0E8", x => x.experience_id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cover_img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    contribution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__projects__BC799E1F2A481118", x => x.project_id);
                });

            migrationBuilder.CreateTable(
                name: "tech_stack_description",
                columns: table => new
                {
                    stack_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stack_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tech_sta__A44AF929B7A3A9B6", x => x.stack_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tech_stack_spec",
                columns: table => new
                {
                    spec_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tool_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    img_src = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(sysdatetime())"),
                    stack_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tech_sta__F670C567B3B5AEFC", x => x.spec_id);
                    table.ForeignKey(
                        name: "FK_stack_spec_description",
                        column: x => x.stack_id,
                        principalTable: "tech_stack_description",
                        principalColumn: "stack_id");
                });

            migrationBuilder.CreateTable(
                name: "exp_projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false),
                    techstack_id = table.Column<int>(type: "int", nullable: false),
                    experienced_at = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechStack", x => new { x.project_id, x.techstack_id, x.experienced_at });
                    table.ForeignKey(
                        name: "FK_ProjectTechStack_Experience",
                        column: x => x.experienced_at,
                        principalTable: "experiences",
                        principalColumn: "experience_id");
                    table.ForeignKey(
                        name: "FK_ProjectTechStack_Project",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "project_id");
                    table.ForeignKey(
                        name: "FK_ProjectTechStack_TechStack",
                        column: x => x.techstack_id,
                        principalTable: "tech_stack_spec",
                        principalColumn: "spec_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_exp_projects_experienced_at",
                table: "exp_projects",
                column: "experienced_at");

            migrationBuilder.CreateIndex(
                name: "IX_exp_projects_techstack_id",
                table: "exp_projects",
                column: "techstack_id");

            migrationBuilder.CreateIndex(
                name: "IX_tech_stack_spec_stack_id",
                table: "tech_stack_spec",
                column: "stack_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exp_projects");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "tech_stack_spec");

            migrationBuilder.DropTable(
                name: "tech_stack_description");
        }
    }
}
