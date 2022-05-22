using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("jenis_pesawat")]
    public class JenisPesawatModel
    {   

        [Key]
        [Column("kode_jenis_pesawat", TypeName ="varchar(30)")]
        public string KodeJenisPesawat { get; set; } = string.Empty;

        [Column("tahun_pesawat", TypeName ="int")]
        public int TahunPesawat { get; set; }

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;


        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;
        

        public JenisPesawatModel() { }

        public JenisPesawatModel(string kodeJenisPesawat,
            int tahunPesawat) { 

            this.KodeJenisPesawat = kodeJenisPesawat;
            this.TahunPesawat = tahunPesawat;

        }

    }
}
