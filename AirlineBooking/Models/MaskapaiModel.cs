using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("maskapai")]
    public class MaskapaiModel
    {       

        [Key]
        [Column("kode_maskapai", TypeName ="varchar(30)")]
        public string KodeMaskapai { get; set; } = string.Empty;

        [Column("nama_maskapai", TypeName = "varchar(60)")]
        public string NamaMaskapai { get; set; } = string.Empty;

        
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;


        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;

        
        public MaskapaiModel() { }

        public MaskapaiModel(string kodeMaskapai, string namaMaskapai) {
            this.KodeMaskapai = kodeMaskapai;
            this.NamaMaskapai = namaMaskapai;
        }
    }
}
