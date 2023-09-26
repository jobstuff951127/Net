using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT_Data.Migrations
{
    /// <inheritdoc />
    public partial class CustmerTypoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerCostumerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerCostumerId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CustomerCostumerId",
                table: "Sales",
                newName: "CustumerId");

            migrationBuilder.RenameColumn(
                name: "CostumerId",
                table: "Sales",
                newName: "CustomerCustumerId");

            migrationBuilder.RenameColumn(
                name: "CostumerId",
                table: "Customers",
                newName: "CustumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerCustumerId",
                table: "Sales",
                column: "CustomerCustumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerCustumerId",
                table: "Sales",
                column: "CustomerCustumerId",
                principalTable: "Customers",
                principalColumn: "CustumerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerCustumerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerCustumerId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CustumerId",
                table: "Sales",
                newName: "CustomerCostumerId");

            migrationBuilder.RenameColumn(
                name: "CustomerCustumerId",
                table: "Sales",
                newName: "CostumerId");

            migrationBuilder.RenameColumn(
                name: "CustumerId",
                table: "Customers",
                newName: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerCostumerId",
                table: "Sales",
                column: "CustomerCostumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerCostumerId",
                table: "Sales",
                column: "CustomerCostumerId",
                principalTable: "Customers",
                principalColumn: "CostumerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
