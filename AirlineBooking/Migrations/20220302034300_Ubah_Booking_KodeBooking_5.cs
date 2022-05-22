using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBooking.Migrations
{
    public partial class Ubah_Booking_KodeBooking_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "kode_booking",
                table: "booking",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "kode_booking",
                table: "booking",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");
        }
    }
}
