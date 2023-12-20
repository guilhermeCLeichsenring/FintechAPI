using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintechAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAB_CATEGORY_TAB_TRANSACTION_id_transaction",
                table: "TAB_CATEGORY");

            migrationBuilder.RenameColumn(
                name: "id_transaction",
                table: "TAB_CATEGORY",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TAB_CATEGORY_id_transaction",
                table: "TAB_CATEGORY",
                newName: "IX_TAB_CATEGORY_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TAB_CATEGORY_TAB_USER_UserId",
                table: "TAB_CATEGORY",
                column: "UserId",
                principalTable: "TAB_USER",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAB_CATEGORY_TAB_USER_UserId",
                table: "TAB_CATEGORY");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TAB_CATEGORY",
                newName: "id_transaction");

            migrationBuilder.RenameIndex(
                name: "IX_TAB_CATEGORY_UserId",
                table: "TAB_CATEGORY",
                newName: "IX_TAB_CATEGORY_id_transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_TAB_CATEGORY_TAB_TRANSACTION_id_transaction",
                table: "TAB_CATEGORY",
                column: "id_transaction",
                principalTable: "TAB_TRANSACTION",
                principalColumn: "id_transaction",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
