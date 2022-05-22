using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class City
    {

        public decimal InitialPenduduk { get; set; }
        public float IncreasePercentage { get; set; }
        public string CityName { get; set; }

        public int InitYear { get; set; }

        public List<KenaikanPenduduk> KenaikanPenduduks { get; set; }

        public City()
        {
            KenaikanPenduduks = new List<KenaikanPenduduk>();
        }
        
        public void CalculateYears(decimal targetPenduduk)
        {

            this.KenaikanPenduduks.Clear();

            decimal currentTotal = InitialPenduduk;
            int years = 0;
            do
            {
                years++;
                decimal increase = 0;
                if (IncreasePercentage < 1)
                {
                    increase = currentTotal * (decimal)IncreasePercentage;
                }
                else
                {
                    increase = currentTotal * (decimal)IncreasePercentage / 100;
                }
                currentTotal = currentTotal + increase;

                var kp = new KenaikanPenduduk();
                kp.JumlahPenduduk = currentTotal;
                kp.JumlahKenaikan = increase;
                kp.Year = this.InitYear + years;

                this.KenaikanPenduduks.Add(kp);

                if (currentTotal > targetPenduduk)
                {
                    break;
                }

            } while (true);


        }

    }

    public class KenaikanPenduduk
    {
        public int Year { get; set; }
        public decimal JumlahPenduduk { get; set; }

        public decimal JumlahKenaikan { get; set; }
    }
}
