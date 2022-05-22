using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBooking.Migrations
{
    public partial class CekComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    kode_booking = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_airport_asal = table.Column<string>(type: "varchar(30)", nullable: false),
                    nama_airport_asal = table.Column<string>(type: "varchar(60)", nullable: false),
                    kode_airport_tujuan = table.Column<string>(type: "varchar(30)", nullable: false),
                    nama_airport_tujuan = table.Column<string>(type: "varchar(60)", nullable: false),
                    tgl_keberangkatan = table.Column<DateTime>(type: "datetime", nullable: false),
                    tgl_kedatangan = table.Column<DateTime>(type: "datetime", nullable: false),
                    durasi = table.Column<int>(type: "int", nullable: false),
                    kode_maskapai = table.Column<string>(type: "varchar(30)", nullable: false),
                    nama_maskapai = table.Column<string>(type: "varchar(60)", nullable: false),
                    kode_penerbangan = table.Column<string>(type: "varchar(30)", nullable: false),
                    batas_bagasi = table.Column<int>(type: "int", nullable: false),
                    batas_bagasi_kabin = table.Column<int>(type: "int", nullable: false),
                    metode_bayar = table.Column<int>(type: "int", nullable: false),
                    harga_tiket = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    jumlah_penumpang = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    kode_pembayaran = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_check_in = table.Column<string>(type: "varchar(30)", nullable: false),
                    status_booking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.kode_booking);
                });

            migrationBuilder.CreateTable(
                name: "booking_penumpang",
                columns: table => new
                {
                    ktp = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_booking = table.Column<string>(type: "varchar(30)", nullable: false),
                    title = table.Column<string>(type: "varchar(3)", nullable: false),
                    nama_penumpang = table.Column<string>(type: "varchar(60)", nullable: false),
                    nomor_kursi = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_penumpang", x => x.ktp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "booking_penumpang");
        }
    }
}
