using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("airport")]
    public class AirportModel
    {

        [Key]
        [Column("kode_airport", TypeName = "varchar(30)")]
        public string KodeAirport { get; set; } = string.Empty;

        [Column("nama_airport", TypeName = "varchar(60)")]
        public string NamaAirport { get; set; } = string.Empty;

        [Column("propinsi", TypeName = "varchar(60)")]
        public string Propinsi { get; set; } = string.Empty;

        [Column("kota", TypeName = "varchar(60)")]
        public string Kota { get; set; }    = string.Empty;
        
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;


        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;


        [ForeignKey("KodeAirport")]
        public List<AirportGatewayModel> Gateways { get; set; } = new List<AirportGatewayModel>();
        public AirportModel() { }

        public AirportModel(string kodeAirport,
            string namaAiport,
            string propinsi,
            string kota) { 
            this.KodeAirport = kodeAirport;
            this.NamaAirport = namaAiport;
            this.Propinsi = propinsi;
            this.Kota = kota;
        }

    }
}
