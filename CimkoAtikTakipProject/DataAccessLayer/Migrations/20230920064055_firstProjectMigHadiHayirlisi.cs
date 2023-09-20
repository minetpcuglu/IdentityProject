using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class firstProjectMigHadiHayirlisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SendEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MonthlyAmount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StockingMethodEnum = table.Column<byte>(type: "tinyint", nullable: true),
                    WasteCodeId = table.Column<int>(type: "int", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SendMailIsSuccess = table.Column<bool>(type: "bit", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteForm_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WasteForm_WasteCode_WasteCodeId",
                        column: x => x.WasteCodeId,
                        principalTable: "WasteCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteFormImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteFormId = table.Column<int>(type: "int", nullable: false),
                    Base64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WasteFormStatusEnum = table.Column<byte>(type: "tinyint", nullable: true),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteFormImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteFormImage_WasteForm_WasteFormId",
                        column: x => x.WasteFormId,
                        principalTable: "WasteForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_CityId",
                table: "District",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteForm_DistrictId",
                table: "WasteForm",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteForm_WasteCodeId",
                table: "WasteForm",
                column: "WasteCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteFormImage_WasteFormId",
                table: "WasteFormImage",
                column: "WasteFormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WasteFormImage");

            migrationBuilder.DropTable(
                name: "WasteForm");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "WasteCode");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
