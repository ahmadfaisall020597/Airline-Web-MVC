using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("kursi_pesawat")]
    public class KursiPesawatModel
    {
        [Key]
        [Column("id_kursi_pesawat", TypeName="bigint")]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public long IDKursiPesawat { get; set; } 

        [Column("kode_penerbangan", TypeName = "varchar(30)")]
        public string KodePenerbangan { get; set; } = string.Empty;

        [Column("nomor_kursi", TypeName = "varchar(5)")]
        public string NomorKursi {  get; set; }     = string.Empty;    

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; }= string.Empty;

        /*[Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;*/

        public KursiPesawatModel() { }

        public KursiPesawatModel(string kodePenerbangan,
            string nomorKursi) { 
            this.KodePenerbangan = kodePenerbangan;
            this.NomorKursi = nomorKursi;
                 
        }

    }
}
