using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Residentials_ID",
                table: "Apartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "Apartment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Factory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FactoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factory_Commercials_ID",
                        column: x => x.ID,
                        principalTable: "Commercials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Num_hotel_rooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotel_Commercials_ID",
                        column: x => x.ID,
                        principalTable: "Commercials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Institutionals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NumFacilities = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutionals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Institutionals_Estates_ID",
                        column: x => x.ID,
                        principalTable: "Estates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    SqMeters = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Villa_Residentials_ID",
                        column: x => x.ID,
                        principalTable: "Residentials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Num_classrooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.ID);
                    table.ForeignKey(
                        name: "FK_School_Institutionals_ID",
                        column: x => x.ID,
                        principalTable: "Institutionals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_Residentials_ID",
                table: "Apartment",
                column: "ID",
                principalTable: "Residentials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_Residentials_ID",
                table: "Apartment");

            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Villa");

            migrationBuilder.DropTable(
                name: "Institutionals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment");

            migrationBuilder.RenameTable(
                name: "Apartment",
                newName: "Apartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Residentials_ID",
                table: "Apartments",
                column: "ID",
                principalTable: "Residentials",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
