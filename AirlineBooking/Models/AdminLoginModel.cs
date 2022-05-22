using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineBooking.Models
{
    [Table("admin_login")]
    public class AdminLoginModel
    {

        [Key]
        [Column("login_id", TypeName = "varchar(100)")]
        public string LoginID { get; set; } = string.Empty;

        [Column("admin_user", TypeName = "varchar(60)")]
        public string AdminUser { get; set; }= string.Empty;

        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("expired", TypeName = "bit")]
        public bool Expired {  get; set; }


    }
}
