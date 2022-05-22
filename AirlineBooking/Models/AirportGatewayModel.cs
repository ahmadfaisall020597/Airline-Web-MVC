using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("airport_gateway")]
    public class AirportGatewayModel
    {
        [Key]
        [Column("id_gateway", TypeName ="bigint")]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IDGateway { get; set; } 

        [Column("kode_airport", TypeName ="varchar(30)")]
        public string KodeAirport { get; set; } = string.Empty;


        /*[ForeignKey("KodeAirport")]
        public AirportModel AirportModel { get; set; } = new AirportModel();*/
        

        [Column("nomor_gate", TypeName = "varchar(5)")]
        public string NomorGate { get; set; }= string.Empty;

        [Column("nomor_pintu", TypeName = "varchar(5)")]
        public string NomorPintu { get; set; }= string.Empty;

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; } = string.Empty;


        /*[Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; } = string.Empty;
        */



        public AirportGatewayModel() { }

        public AirportGatewayModel(string kodeAirport,
            string nomorGate,
            string nomorPintu) { 
            this.KodeAirport = kodeAirport;
            this.NomorGate = nomorGate;
            this.NomorPintu = nomorPintu;
        }

    }
}
