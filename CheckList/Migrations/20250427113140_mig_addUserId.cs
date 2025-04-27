using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckList.Migrations
{
    /// <inheritdoc />
    public partial class mig_addUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCheckListItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCheckListItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCheckListItems_Users_UserId",
                table: "UserCheckListItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
