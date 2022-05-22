using System.ComponentModel.DataAnnotations;

namespace AirlineBookingMVC.Areas.Admin.ViewModels.Schedule;

public class DetailsScheduleViewModel : BaseViewModel
{
    [Display(Name="ID Jadwal")]
    public long ScheduleID { get; set; }

    [Display(Name="Kode Maskapai")]
    public string KodeMaskapai { get; set; } = string.Empty;

    [Display(Name="Nama Maskapai")]
    public string NamaMaskapai { get; set; } = string.Empty;

    [Display(Name="Kode Penerbangan")]
    public string KodePenerbangan { get; set; } = string.Empty;

    [Display(Name="Kode Bandara Asal")]
    public string KodeAirportAsal { get; set; } = string.Empty;

    [Display(Name="Nama Bandara Asal")]
    public string NamaAirportAsal { get; set; } = string.Empty;

    
    [Display(Name="Kode Bandara Tujuan")]
    public string KodeAirportTujuan { get; set; } = string.Empty;

    [Display(Name="Nama Bandara Asal")]
    public string NamaAirportTujuan { get; set; } = string.Empty;
    
    [Display(Name="Tgl. Keberangkatan")]
    public DateTime TglKeberangkatan { get; set; } 

    [Display(Name="Tgl. Kedatangan")]
    public DateTime TglKedatangan { get; set; }
    
    [Display(Name="Batas Bagasi")]
    public int BatasBagasi { get; set; }

    [Display(Name="Batas Bagasi Kabin")]
    public int BatasBagasiKabin { get; set; }

    [Display(Name="Harga Tiket")]
    public decimal HargaTiket { get; set; }

    [Display(Name="Tgl.Buat")]
    public DateTime CreatedAt { get; set; }

    [Display(Name="Dibuat oleh")]
    public string CreatedBy { get; set; } = string.Empty;

    [Display(Name="Tgl.Ubah")]
    public DateTime? UpdatedAt { get; set; }

    [Display(Name="Diubah oleh")]
    public string? UpdatedBy { get; set; } = string.Empty;

}