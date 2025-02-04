using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SavedJobId",
                table: "Jobs",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavedJobId",
                table: "Jobs");
        }
    }
}
