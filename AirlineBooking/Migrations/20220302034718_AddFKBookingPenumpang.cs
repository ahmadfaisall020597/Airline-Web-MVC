using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBooking.Migrations
{

    public partial class AddFKBookingPenumpang : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_booking_penumpang_kode_booking",
                table: "booking_penumpang",
                column: "kode_booking");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_penumpang_booking_kode_booking",
                table: "booking_penumpang",
                column: "kode_booking",
                principalTable: "booking",
                principalColumn: "kode_booking",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_booking_penumpang_booking_kode_booking",
                table: "booking_penumpang");

            migrationBuilder.DropIndex(
                name: "IX_booking_penumpang_kode_booking",
                table: "booking_penumpang");
        }


    }
}
