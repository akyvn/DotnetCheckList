using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckList.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserCheckListItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCheckListItems_UserId",
                table: "UserCheckListItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems");

            migrationBuilder.DropIndex(
                name: "IX_UserCheckListItems_UserId",
                table: "UserCheckListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCheckListItems");
        }
    }
}
