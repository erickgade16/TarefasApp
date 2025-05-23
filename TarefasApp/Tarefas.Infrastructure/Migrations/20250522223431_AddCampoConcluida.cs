using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarefas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCampoConcluida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluido",
                table: "Tarefas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluido",
                table: "Tarefas");
        }
    }
}
