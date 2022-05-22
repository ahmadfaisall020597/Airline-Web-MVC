using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBooking.Migrations
{
    public partial class AddKursiPesawat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kursi_pesawat",
                columns: table => new
                {
                    id_kursi_pesawat = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_penerbangan = table.Column<string>(type: "varchar(30)", nullable: false),
                    nomor_kursi = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kursi_pesawat", x => x.id_kursi_pesawat);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kursi_pesawat");
        }
    }
}
