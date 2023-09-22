using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FactoryWasteForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "WasteForm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WasteForm_FactoryId",
                table: "WasteForm",
                column: "FactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WasteForm_Factory_FactoryId",
                table: "WasteForm",
                column: "FactoryId",
                principalTable: "Factory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WasteForm_Factory_FactoryId",
                table: "WasteForm");

            migrationBuilder.DropIndex(
                name: "IX_WasteForm_FactoryId",
                table: "WasteForm");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "WasteForm");
        }
    }
}
