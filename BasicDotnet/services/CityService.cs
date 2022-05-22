using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.services
{
    public class CityService
    {

        private List<models.City> _cities = new List<models.City>();

        public void AddCity(string cityName, int initYear,
            decimal initialPenduduk, float increasePercentange)
        {
            var _city = new models.City();
            _city.CityName = cityName;
            _city.InitYear = initYear;
            _city.InitialPenduduk = initialPenduduk;
            _city.IncreasePercentage = increasePercentange;
            _cities.Add(_city);
        }

        public void CalculateYears(decimal targetPenduduk)
        {
            for (int i=0;i<_cities.Count;i++)
            {
                _cities[i].CalculateYears(targetPenduduk);
            }

            printCities();

        }

        private string formatIncreaseP(float increaseP)
        {
            if(increaseP >= 1f)
            {
                return string.Format("{0}%", increaseP);
            } else
            {
                return string.Format("{0}%", increaseP * 100);
            }
        }


        private void printCities()
        {
            for (int i = 0; i < _cities.Count; i++)
            {
                var _city = _cities[i];
                Console.WriteLine("==========================================================");
                Console.WriteLine("Nama City: {0}, Init Year={1}, Init Penduduk {2}, Increase P {3} ", 
                    _city.CityName,
                    _city.InitYear,
                    _city.InitialPenduduk,
                    formatIncreaseP(_city.IncreasePercentage)
                    );
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Histori Kenaikan Penduduk");
                Console.WriteLine("-----------------------------------------------------------");

                for(int j=0;j<_city.KenaikanPenduduks.Count;j++)
                {
                    var kp = _city.KenaikanPenduduks[j];
                    Console.WriteLine("Pada Tahun Ke- {0}, Kenaikan={1}, Jumlah Penduduk={2}", 
                        kp.Year,
                        Math.Round(kp.JumlahKenaikan,0),
                        Math.Round(kp.JumlahPenduduk, 0)
                        );
                }

                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

            }
        }

        public models.City FindByName(string name)
        {
            /*             
            [yudi] => name == 'fathan'?
            [fathan] => name == 'fathan'?
            []
            []
            []
            []
            []
            []
             */
            models.City _city = new models.City();
            _city = _cities.Where(x => x.CityName.ToLower() == name.ToLower()).First();
            return _city;
        }
    }
}
