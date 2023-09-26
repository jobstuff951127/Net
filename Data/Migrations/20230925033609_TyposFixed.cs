using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTT_Data.Migrations
{
    /// <inheritdoc />
    public partial class TyposFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerCustumerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerCustumerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerCustumerId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CustumerId",
                table: "Sales",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "UnitPrice",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustumerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Sales",
                newName: "CustumerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerCustumerId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UnitPrice",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
