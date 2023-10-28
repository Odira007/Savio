using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavioApi.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountBalance = table.Column<double>(type: "REAL", nullable: false),
                    BankName = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountCreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => new { x.UserId, x.AccountNumber });
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TransactionType = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionSender = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionReceiver = table.Column<Guid>(type: "TEXT", nullable: false),
                    TransactionAmount = table.Column<double>(type: "REAL", nullable: false),
                    TransactionStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountUserId_AccountNumber",
                        columns: x => new { x.AccountUserId, x.AccountNumber },
                        principalTable: "Accounts",
                        principalColumns: new[] { "UserId", "AccountNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    BVN = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AccountUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_AccountUserId_AccountNumber",
                        columns: x => new { x.AccountUserId, x.AccountNumber },
                        principalTable: "Accounts",
                        principalColumns: new[] { "UserId", "AccountNumber" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountUserId_AccountNumber",
                table: "Transactions",
                columns: new[] { "AccountUserId", "AccountNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountUserId_AccountNumber",
                table: "Users",
                columns: new[] { "AccountUserId", "AccountNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
