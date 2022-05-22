using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("schedule")]
    public class ScheduleModel
    {

        [Key]
        [Column("schedule_id", TypeName = "bigint")]
        public long ScheduleID { get; set; }

        [Column("kode_maskapai", TypeName = "varchar(30)")]
        public string KodeMaskapai { get; set; } = string.Empty;

        [Column("kode_penerbangan", TypeName = "varchar(30)")]
        public string KodePenerbangan { get; set; } = string.Empty;

        [Column("kode_asal_airport", TypeName = "varchar(30)")]
        public string KodeAirportAsal { get; set; } = string.Empty;

        [Column("kode_asal_tujuan", TypeName = "varchar(30)")]
        public string KodeAirportTujuan { get; set; } = string.Empty;

        [Column("tgl_keberangkatan", TypeName = "datetime")]
        public DateTime TglKeberangkatan { get; set; } 


        [Column("tgl_kedatangan", TypeName = "datetime")]
        public DateTime TglKedatangan { get; set; }


        [Column("batas_bagasi", TypeName = "int")]
        public int BatasBagasi { get; set; }

        [Column("batas_bagasi_kabin", TypeName = "int")]
        public int BatasBagasiKabin { get; set; }


        [Column("harga_tiket", TypeName = "decimal(18,2)")]
        public decimal HargaTiket { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;


        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;
        
        
        
        [ForeignKey("KodeMaskapai")] 
        public MaskapaiModel Maskapai { get; set; } = new MaskapaiModel();

        [ForeignKey("KodePenerbangan")] public PesawatModel Pesawat { get; set; } = new PesawatModel();
            

        [ForeignKey("KodeAirportAsal")]
        public AirportModel AirportAsal { get; set; } = new AirportModel();

        [ForeignKey("KodeAirportTujuan")]
        public AirportModel AirportTujuan { get; set; } = new AirportModel();

        
        


      

        

        [NotMapped]
        public string StrTglKeberangkatan { get; set; } = string.Empty;

        [NotMapped]
        public string StrTglKedatangan { get; set; } = string.Empty;

        public ScheduleModel() { }


        public ScheduleModel(string kodeMaskapai,
            string kodePenerbangan,
            string kodeAirportAsal,
            string kodeAirportTujuan,
            string tglKeberangkatan,
            string tglKedatangan,
            int batasBagasi,
            int batasBagasiKabin)
        {

            this.KodeMaskapai = kodeMaskapai;
            this.KodePenerbangan = kodePenerbangan;
            this.KodeAirportAsal = kodeAirportAsal;
            this.KodeAirportTujuan = kodeAirportTujuan;
            this.StrTglKeberangkatan = tglKeberangkatan;
            this.StrTglKedatangan = tglKedatangan;
            this.BatasBagasi = batasBagasi;
            this.BatasBagasiKabin = batasBagasiKabin;

        }


    }
}
