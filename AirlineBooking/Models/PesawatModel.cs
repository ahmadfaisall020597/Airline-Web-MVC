using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{

    [Table("pesawat")]
    public class PesawatModel
    {

        [Key]
        [Column("kode_penerbangan", TypeName = "varchar(30)")]
        public string KodePenerbangan { get; set; } = string.Empty; 

        [Column("kode_jenis_pesawat", TypeName = "varchar(30)")]
        public string KodeJenisPesawat { get; set; } = string.Empty; 

        [Column("kode_maskapai", TypeName = "varchar(30)")]
        public string KodeMaskapai { get; set; } = string.Empty;

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

        [ForeignKey("KodeJenisPesawat")] public JenisPesawatModel JenisPesawat { get; set; } = new JenisPesawatModel();

        [ForeignKey("KodePenerbangan")]
        public List<KursiPesawatModel> KursiPesawats { get; set; } = new List<KursiPesawatModel>();
        
        public PesawatModel() { }

        public PesawatModel(string kodePenerbangan, 
            string kodeJenisPesawat,
            string kodeMaskapai) { 
        
            this.KodePenerbangan = kodePenerbangan;
            this.KodeJenisPesawat = kodeJenisPesawat;
            this.KodeMaskapai = kodeMaskapai;
        }

    }
}
