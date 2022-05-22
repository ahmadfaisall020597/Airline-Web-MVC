using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace AirlineBooking.Models
{
    public class AirlineBookingDbContext :DbContext
    {

        /* tables */
        public DbSet<AdminUserModel> AdminUsers { get; set; }

        public DbSet<AdminLoginModel> AdminLogins { get; set; }

        public DbSet<PassengerUserModel> PassengerUsers { get; set; }

        public DbSet<AirportGatewayModel> AirportGateways { get; set; }

        public DbSet<AirportModel> Airports { get; set; }

        public DbSet<BookingModel> Bookings{ get; set; }

        public DbSet<BookingPenumpangModel> BookingPenumpangs { get; set; }

        public DbSet<JenisPesawatModel> JenisPesawats { get; set; }

        public DbSet<KursiPesawatModel> KursiPesawats { get; set; }

        public DbSet<MaskapaiModel> Maskapaies { get; set; }

        public DbSet<PesawatModel> Pesawats { get; set; }

        public DbSet<ScheduleModel> Schedules { get; set; }




        /*constructors*/


        public AirlineBookingDbContext(DbContextOptions<AirlineBookingDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
              

        /*Configurasi DbContext*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUserModel>();

            modelBuilder.Entity<AdminLoginModel>();

            modelBuilder.Entity<PassengerUserModel>();

            modelBuilder.Entity<ScheduleModel>();               
            
            modelBuilder.Entity<AirportModel>();

            modelBuilder.Entity<MaskapaiModel>();

            modelBuilder.Entity<JenisPesawatModel>();

            modelBuilder.Entity<PesawatModel>();

            modelBuilder.Entity<AirportGatewayModel>();

        }

    }

    public class AirlineBookingDbContextFactory : IDesignTimeDbContextFactory<AirlineBookingDbContext>
    {
        public AirlineBookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AirlineBookingDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AIRLINE_BOOKING;User Id=sa;Password=123456;");

            return new AirlineBookingDbContext(optionsBuilder.Options);
        }
    }
}
