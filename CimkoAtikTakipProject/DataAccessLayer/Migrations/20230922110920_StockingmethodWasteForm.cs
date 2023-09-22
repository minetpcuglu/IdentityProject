using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class StockingmethodWasteForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockingMethodId",
                table: "WasteForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WasteForm_StockingMethodId",
                table: "WasteForm",
                column: "StockingMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteForm_StockingMethod_StockingMethodId",
                table: "WasteForm",
                column: "StockingMethodId",
                principalTable: "StockingMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteForm_StockingMethod_StockingMethodId",
                table: "WasteForm");

            migrationBuilder.DropIndex(
                name: "IX_WasteForm_StockingMethodId",
                table: "WasteForm");

            migrationBuilder.DropColumn(
                name: "StockingMethodId",
                table: "WasteForm");
        }
    }
}
