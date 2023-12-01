using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transfer.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMethodsRenamed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Currencies_CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Users_UserId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentMethods_RecipientId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentMethods_SenderId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethods_UserId",
                table: "Accounts",
                newName: "IX_Accounts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethods_CurrencyId",
                table: "Accounts",
                newName: "IX_Accounts_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_RecipientId",
                table: "Transactions",
                column: "RecipientId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SenderId",
                table: "Transactions",
                column: "SenderId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Currencies_CurrencyId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_RecipientId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SenderId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "PaymentMethods");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_UserId",
                table: "PaymentMethods",
                newName: "IX_PaymentMethods_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_CurrencyId",
                table: "PaymentMethods",
                newName: "IX_PaymentMethods_CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Currencies_CurrencyId",
                table: "PaymentMethods",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Users_UserId",
                table: "PaymentMethods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentMethods_RecipientId",
                table: "Transactions",
                column: "RecipientId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentMethods_SenderId",
                table: "Transactions",
                column: "SenderId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
