using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavioApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedthetransactionmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionReceiver",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionSender",
                table: "Transactions",
                newName: "ReceivingAccount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionUpdatedAt",
                table: "Transactions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivingAccount",
                table: "Transactions",
                newName: "TransactionSender");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionUpdatedAt",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionReceiver",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TransactionStatus",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
