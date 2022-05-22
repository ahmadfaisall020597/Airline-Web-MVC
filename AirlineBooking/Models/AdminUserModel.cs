using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("admin_user")]
    public class AdminUserModel
    {

        [Key]
        [Column("email", TypeName = "varchar(60)")]
        public string Email { get; set; } = string.Empty;

        [Column("password", TypeName = "varchar(100)")]
        public string Password { get; set; }= string.Empty;

        [Column("username", TypeName = "varchar(60)")]
        public string Username { get; set; }    = string.Empty;

        [Column("active", TypeName = "bit")]
        public bool Active { get; set; }


        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by", TypeName = "varchar(60)")]
        public string CreatedBy { get; set; }= string.Empty;


        [Column("updated_at", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by", TypeName = "varchar(60)")]
        public string? UpdatedBy { get; set; }= string.Empty;


    }
}
