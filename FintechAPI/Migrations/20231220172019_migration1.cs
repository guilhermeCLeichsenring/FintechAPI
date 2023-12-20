using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FintechAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TAB_BANK",
                columns: table => new
                {
                    id_bank = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    label = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_BANK", x => x.id_bank);
                });

            migrationBuilder.CreateTable(
                name: "TAB_USER",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    password = table.Column<string>(type: "NVARCHAR2(16)", maxLength: 16, nullable: false),
                    phone_number = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_USER", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "TAB_CATEGORY",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_transaction = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_CATEGORY", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "TAB_TRANSACTION",
                columns: table => new
                {
                    id_transaction = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    value = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    type = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    id_user = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_category = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_bank = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAB_TRANSACTION", x => x.id_transaction);
                    table.ForeignKey(
                        name: "FK_TAB_TRANSACTION_TAB_BANK_id_bank",
                        column: x => x.id_bank,
                        principalTable: "TAB_BANK",
                        principalColumn: "id_bank",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAB_TRANSACTION_TAB_CATEGORY_id_category",
                        column: x => x.id_category,
                        principalTable: "TAB_CATEGORY",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAB_TRANSACTION_TAB_USER_id_user",
                        column: x => x.id_user,
                        principalTable: "TAB_USER",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAB_CATEGORY_id_transaction",
                table: "TAB_CATEGORY",
                column: "id_transaction");

            migrationBuilder.CreateIndex(
                name: "IX_TAB_TRANSACTION_id_bank",
                table: "TAB_TRANSACTION",
                column: "id_bank");

            migrationBuilder.CreateIndex(
                name: "IX_TAB_TRANSACTION_id_category",
                table: "TAB_TRANSACTION",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_TAB_TRANSACTION_id_user",
                table: "TAB_TRANSACTION",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_TAB_CATEGORY_TAB_TRANSACTION_id_transaction",
                table: "TAB_CATEGORY",
                column: "id_transaction",
                principalTable: "TAB_TRANSACTION",
                principalColumn: "id_transaction",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAB_CATEGORY_TAB_TRANSACTION_id_transaction",
                table: "TAB_CATEGORY");

            migrationBuilder.DropTable(
                name: "TAB_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TAB_BANK");

            migrationBuilder.DropTable(
                name: "TAB_CATEGORY");

            migrationBuilder.DropTable(
                name: "TAB_USER");
        }
    }
}
