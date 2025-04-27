using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckList.Migrations
{
    /// <inheritdoc />
    public partial class issoftdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSoftDeleted",
                table: "UserCheckListItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsSoftDeleted",
                table: "UserCheckListItems");
        }
    }
}
