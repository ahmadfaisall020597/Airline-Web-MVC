using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Schedule;

public class ScheduleViewModel : BaseViewModel
{
    [Display(Name = "ID Jadwal")] public long ScheduleID;

    [Display(Name = "Kode Maskapai")] public string KodeMaskapai;

    [Display(Name = "Nama Maskapai")] public string NamaMaskapai;

    [Display(Name = "Kode Penerbangan")] public string KodePenerbangan;

    [Display(Name = "Kode Bandara Asal")] public string KodeAirportAsal;

    [Display(Name = "Nama Bandara Asal")] public string NamaAirportAsal;


    [Display(Name = "Kode Bandara Tujuan")] public string KodeAirportTujuan;

    [Display(Name = "Nama Bandara Asal")] public string NamaAirportTujuan;

    [Display(Name = "Tgl. Keberangkatan")] public DateTime TglKeberangkatan;

    [Display(Name = "Tgl. Kedatangan")] public DateTime TglKedatangan;

    [Display(Name = "Batas Bagasi")] public int BatasBagasi;

    [Display(Name = "Batas Bagasi Kabin")] public int BatasBagasiKabin;

    [Display(Name = "Harga Tiket")] public decimal HargaTiket;


}