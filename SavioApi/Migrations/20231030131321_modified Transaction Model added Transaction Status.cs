using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SavioApi.Migrations
{
    /// <inheritdoc />
    public partial class modifiedTransactionModeladdedTransactionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionStatus",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionStatus",
                table: "Transactions");
        }
    }
}
