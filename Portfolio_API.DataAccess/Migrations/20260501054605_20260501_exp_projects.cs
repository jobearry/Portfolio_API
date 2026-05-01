using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _20260501_exp_projects : Migration
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
                    role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__experien__EB216AFC5362759B", x => x.experience_id);
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
                    table.PrimaryKey("PK__projects__BC799E1F26444275", x => x.project_id);
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
                    table.PrimaryKey("PK__tech_sta__A44AF9293BF4000B", x => x.stack_id);
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
                    table.PrimaryKey("PK__tech_sta__F670C567E44DDEB0", x => x.spec_id);
                    table.ForeignKey(
                        name: "FK_stack_spec_description",
                        column: x => x.stack_id,
                        principalTable: "tech_stack_description",
                        principalColumn: "stack_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tech_stack_spec_stack_id",
                table: "tech_stack_spec",
                column: "stack_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
