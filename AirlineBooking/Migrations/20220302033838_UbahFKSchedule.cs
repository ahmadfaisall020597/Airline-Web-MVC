using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBooking.Migrations
{
    public partial class UbahFKSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airport",
                columns: table => new
                {
                    kode_airport = table.Column<string>(type: "varchar(30)", nullable: false),
                    nama_airport = table.Column<string>(type: "varchar(60)", nullable: false),
                    propinsi = table.Column<string>(type: "varchar(60)", nullable: false),
                    kota = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport", x => x.kode_airport);
                });

            migrationBuilder.CreateTable(
                name: "airport_gateway",
                columns: table => new
                {
                    id_gateway = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kode_airport = table.Column<string>(type: "varchar(30)", nullable: false),
                    nomor_gate = table.Column<string>(type: "varchar(5)", nullable: false),
                    nomor_pintu = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airport_gateway", x => x.id_gateway);
                });

            migrationBuilder.CreateTable(
                name: "jenis_pesawat",
                columns: table => new
                {
                    kode_jenis_pesawat = table.Column<string>(type: "varchar(30)", nullable: false),
                    tahun_pesawat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jenis_pesawat", x => x.kode_jenis_pesawat);
                });

            migrationBuilder.CreateTable(
                name: "maskapai",
                columns: table => new
                {
                    kode_maskapai = table.Column<string>(type: "varchar(30)", nullable: false),
                    nama_maskapai = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maskapai", x => x.kode_maskapai);
                });

            migrationBuilder.CreateTable(
                name: "pesawat",
                columns: table => new
                {
                    kode_penerbangan = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_jenis_pesawat = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_maskapai = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pesawat", x => x.kode_penerbangan);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    schedule_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kode_maskapai = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_penerbangan = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_asal_airport = table.Column<string>(type: "varchar(30)", nullable: false),
                    kode_asal_tujuan = table.Column<string>(type: "varchar(30)", nullable: false),
                    tgl_keberangkatan = table.Column<DateTime>(type: "datetime", nullable: false),
                    tgl_kedatangan = table.Column<DateTime>(type: "datetime", nullable: false),
                    batas_bagasi = table.Column<int>(type: "int", nullable: false),
                    batas_bagasi_kabin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.schedule_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "airport");

            migrationBuilder.DropTable(
                name: "airport_gateway");

            migrationBuilder.DropTable(
                name: "jenis_pesawat");

            migrationBuilder.DropTable(
                name: "maskapai");

            migrationBuilder.DropTable(
                name: "pesawat");

            migrationBuilder.DropTable(
                name: "schedule");
        }
    }
}
