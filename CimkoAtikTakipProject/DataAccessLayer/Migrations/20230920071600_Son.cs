using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Son : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durum",
                table: "WasteFormImage");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "WasteForm");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "WasteCode");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Factory");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "District");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "WasteFormImage",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "WasteForm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "WasteCode",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "Factory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "District",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Durum",
                table: "City",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
