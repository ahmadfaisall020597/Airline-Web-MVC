using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("booking")]
    public class BookingModel
    {
        [Key]
        [Column("kode_booking", TypeName = "varchar(5)")]
        public string KodeBooking {  get; set; }  = string.Empty;
        
        [Column("kode_airport_asal", TypeName = "varchar(30)")]
        public string KodeAirportAsal { get; set; } = string.Empty;
        
        [Column("nama_airport_asal", TypeName = "varchar(60)")]
        public string NamaAirportAsal { get; set; } = string.Empty;
        
        [Column("kode_airport_tujuan", TypeName = "varchar(30)")]
        public string KodeAirportTujuan { get; set; } = string.Empty;

        [Column("nama_airport_tujuan", TypeName = "varchar(60)")]
        public string NamaAirportTujuan { get; set; } = string.Empty;

        [Column("tgl_keberangkatan", TypeName = "datetime")]
        public DateTime TglKeberangkatan { get; set; } 

        [Column("tgl_kedatangan", TypeName = "datetime")]
        public DateTime TglKedatangan { get; set; }



        [Column("durasi", TypeName = "int")]
        public double Durasi { get; set; }


        [Column("kode_maskapai", TypeName = "varchar(30)")]
        public string KodeMaskapai { get; set; } = string.Empty;

        [Column("nama_maskapai", TypeName = "varchar(60)")]
        public string NamaMaskapai { get; set; } = string.Empty;

        [Column("kode_penerbangan", TypeName = "varchar(30)")]
        public string KodePenerbangan { get; set; } = string.Empty;

        [Column("batas_bagasi", TypeName = "int")]
        public int BatasBagasi { get; set; }

        [Column("batas_bagasi_kabin", TypeName = "int")]
        public int BatasBagasiKabin { get; set; }

        [Column("metode_bayar", TypeName = "int")]
        public int MetodeBayar { get; set; }

        [Column("harga_tiket", TypeName = "decimal(18,2)")]
        public decimal HargaTiket { get; set; }

        [Column("jumlah_penumpang", TypeName = "int")]
        public int JumlahPenumpang { get; set; }

        [Column("total", TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Column("jumlah_bayar", TypeName = "decimal(18,2)")]
        public decimal JumlahBayar { get; set; }


        [Column("kode_pembayaran", TypeName = "varchar(30)")]
        public string KodePembayaran { get; set; } = string.Empty;

        [Column("kode_check_in", TypeName = "varchar(30)")]
        public string KodeCheckIn { get; set; } = string.Empty;

        [Column("status_booking", TypeName = "int")]
        public int StatusBooking { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;

        [ForeignKey("KodeBooking")]
        public List<BookingPenumpangModel> Penumpangs { get; set; }

    }
}
