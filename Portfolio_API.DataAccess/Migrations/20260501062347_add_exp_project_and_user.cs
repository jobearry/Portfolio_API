using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_exp_project_and_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__tech_sta__F670C567E44DDEB0",
                table: "tech_stack_spec");

            migrationBuilder.DropPrimaryKey(
                name: "PK__tech_sta__A44AF9293BF4000B",
                table: "tech_stack_description");

            migrationBuilder.DropPrimaryKey(
                name: "PK__projects__BC799E1F26444275",
                table: "projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK__experien__EB216AFC5362759B",
                table: "experiences");

            migrationBuilder.AddPrimaryKey(
                name: "PK__tech_sta__F670C567B3B5AEFC",
                table: "tech_stack_spec",
                column: "spec_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__tech_sta__A44AF929B7A3A9B6",
                table: "tech_stack_description",
                column: "stack_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__projects__BC799E1F2A481118",
                table: "projects",
                column: "project_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__experien__EB216AFCB14726DD",
                table: "experiences",
                column: "experience_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_exp_projects_experienced_at",
                table: "exp_projects",
                column: "experienced_at");

            migrationBuilder.CreateIndex(
                name: "IX_exp_projects_techstack_id",
                table: "exp_projects",
                column: "techstack_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exp_projects");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__tech_sta__F670C567B3B5AEFC",
                table: "tech_stack_spec");

            migrationBuilder.DropPrimaryKey(
                name: "PK__tech_sta__A44AF929B7A3A9B6",
                table: "tech_stack_description");

            migrationBuilder.DropPrimaryKey(
                name: "PK__projects__BC799E1F2A481118",
                table: "projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK__experien__EB216AFCB14726DD",
                table: "experiences");

            migrationBuilder.AddPrimaryKey(
                name: "PK__tech_sta__F670C567E44DDEB0",
                table: "tech_stack_spec",
                column: "spec_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__tech_sta__A44AF9293BF4000B",
                table: "tech_stack_description",
                column: "stack_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__projects__BC799E1F26444275",
                table: "projects",
                column: "project_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__experien__EB216AFC5362759B",
                table: "experiences",
                column: "experience_id");
        }
    }
}
