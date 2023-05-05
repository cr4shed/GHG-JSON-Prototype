using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonPrototype.Migrations
{
    /// <inheritdoc />
    public partial class Dictionary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivitiesDictionary",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivitiesDictionary",
                table: "Reports");
        }
    }
}
