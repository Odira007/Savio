using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavioApi.Migrations
{
    /// <inheritdoc />
    public partial class renamedmodelsfromuserstousersandaccounttoUserAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_AccountUserId_AccountNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AccountUserId",
                table: "Users",
                newName: "UserAccountUserId");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Users",
                newName: "UserAccountAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AccountUserId_AccountNumber",
                table: "Users",
                newName: "IX_Users_UserAccountUserId_UserAccountAccountNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionUpdatedAt",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_UserAccountUserId_UserAccountAccountNumber",
                table: "Users",
                columns: new[] { "UserAccountUserId", "UserAccountAccountNumber" },
                principalTable: "Accounts",
                principalColumns: new[] { "UserId", "AccountNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Accounts_UserAccountUserId_UserAccountAccountNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TransactionUpdatedAt",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UserAccountUserId",
                table: "Users",
                newName: "AccountUserId");

            migrationBuilder.RenameColumn(
                name: "UserAccountAccountNumber",
                table: "Users",
                newName: "AccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserAccountUserId_UserAccountAccountNumber",
                table: "Users",
                newName: "IX_Users_AccountUserId_AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Accounts_AccountUserId_AccountNumber",
                table: "Users",
                columns: new[] { "AccountUserId", "AccountNumber" },
                principalTable: "Accounts",
                principalColumns: new[] { "UserId", "AccountNumber" });
        }
    }
}
