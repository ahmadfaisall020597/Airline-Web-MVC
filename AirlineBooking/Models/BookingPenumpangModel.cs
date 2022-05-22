using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace AirlineBooking.Models
{
    [Table("booking_penumpang")]
    public class BookingPenumpangModel
    {
        [Key]
        [Column("ktp", TypeName = "varchar(30)")]
        public string KTP { get; set; } = string.Empty;

        [Column("kode_booking", TypeName = "varchar(5)")]
        public string KodeBooking {  get; set; } = string.Empty;

        [Column("title", TypeName = "varchar(3)")]
        public string Title { get; set; } = string.Empty;

        [Column("nama_penumpang", TypeName = "varchar(60)")]
        public string NamaPenumpang { get; set; } = string.Empty;

        [Column("nomor_kursi", TypeName = "varchar(5)")]
        public string NomorKursi { get; set; } = string.Empty;

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;

        
        public BookingPenumpangModel() { }

        public BookingPenumpangModel(string ktp,
            string title,
            string namaPenumpang) {
            this.KTP = ktp;
            this.Title = title;
            this.NamaPenumpang = namaPenumpang;
        }

    }
}
