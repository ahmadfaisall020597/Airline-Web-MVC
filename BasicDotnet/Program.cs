//Ctl + Shift +  / => comment block / uncoment block
//Ctl + K, Ctl + / => comment line / uncomment line
//Ctl + K, Ctl + F => arrange code / format
//F5 => debugging
//Ctl + F5 => run
//Ctl + Space => lookup information
//Ctl + -  => back to last position
//Ctl + Shift + -  => forward to last position
//F12 => go to definition
//Ctl + m, Ctl + L => Toggle collapse atau open line defintion


using System.Text;
using BasicDotnet;
namespace BasicDotnet
{


    class Program
    {

        static void Main(string[] args)
        {
            /*
            writeline();
            dataTypes();
            accountBalances();
            conditionalAndLoop();
            learnDictionary();
            searchEmployeeArr();
            belajarArray();
            belajarSearch();
            belajarClass();
            belajarSplitStrings();
            */

            //views.Chatbot.Chatbot chatbot = new views.Chatbot.Chatbot();
            /*var makhluk = new methods.Makhluk();
            Console.WriteLine("GetNyawa={0}", makhluk.GetNyawa());
            Console.WriteLine("GetNyawaOrNull={0}", makhluk.GetNyawaOrNull());
            makhluk.CetakNyawa();*/

            /*decimal targetPenduduk = 100000;
            services.CityService _cityService = new services.CityService();
            _cityService.AddCity("Bogor", 2022, 30000, 3f);
            _cityService.AddCity("Tangerang", 2022, 45000, 10f);
            _cityService.AddCity("Jakarta", 2022, 10000000, 1f);
            _cityService.CalculateYears(targetPenduduk);*/

            /*services.WordCount _wordCount = new services.WordCount();
            var _wordCounts = _wordCount.Count("met malam bapak ibu, met sore bapak-bapak & ibu-ibu met pagi bapak/ibu, apa kabar?, baik-baik saja, dan_aku");
            _wordCount.PrintCount();

            Console.WriteLine();
            services.CompareInput _compareInput = new services.CompareInput("bapak/ibu, apa kabar?");
            _ = _compareInput.Compare(_wordCounts);
            _compareInput.PrintOutput();*/

            var results = services.Splitter.SplitLine(@"
The novella as a literary genre began developing in the Italian 
literature of the early Renaissance, principally Giovanni Boccaccio, 
author of The Decameron (1353).[5] The Decameron featured 100 tales 
(named novellas) told by ten people (seven women and three men) 
fleeing the Black Death, by escaping from Florence to the Fiesole hills in 1348. 
This structure was then imitated by subsequent authors, notably the French queen 
Marguerite de Navarre, whose Heptaméron (1559) included 72 original French tales 
and was modeled after the structure of The Decameron.
");



        }


        static void writeline()
        {

        }

        static void dataTypes()
        {
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("DAFTAR KARYAWAN");
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("kode karyawan\t|nama karyawan\t|mulai bekerja\t|masih bekerja\t|gaji\t|tinggi badan\t|");
            Console.WriteLine("=======================================================================================");


            // data types

            string employeeCode = "E001";
            string employeeName = "Faisal";
            DateTime startWorking = DateTime.Parse("2022-02-10");
            bool stillWorking = true;
            decimal salary = 5000000;
            float bodyHeight = 175.5f;


            /*conditional inline
            (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja") 

             => sama dengan

            if(stillWorking)
            {
                return "Masih Bekerja";
            } else
            {
                return "Sudah tidak bekerja"
            }*/


            //C# Datetime format
            /*
            DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")	
            2015 - 05 - 16T05: 50:06

            DateTime.Now.ToString("HH:mm")  
            05:50

            DateTime.Now.ToString("hh:mm tt")   
            05:50 AM

            DateTime.Now.ToString("H:mm")   
            5:50
            */

            Console.WriteLine("{0}\t|{1}\t|{2}\t|{3}\t|{4}\t|{5}\t|",
                employeeCode,
                employeeName,
                startWorking.ToString("yyyy-MM-dd"),
                (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"),
                salary,
                bodyHeight);


            employeeCode = "E002";
            employeeName = "Vido";
            startWorking = DateTime.Parse("2022-02-11");
            stillWorking = false;
            salary = 1000000;
            bodyHeight = 160.2f;

            //{0}, {1}, ... {5} ..format
            Console.WriteLine("{0}\t|{1}\t|{2}\t|{3}\t|{4}\t|{5}\t|",
                employeeCode,
                employeeName,
                startWorking.ToString("yyyy-MM-dd"),
                (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"),
                salary,
                bodyHeight);



            employeeCode = "E003";
            employeeName = "Dinda";
            startWorking = DateTime.Parse("2022-02-11");
            stillWorking = true;
            salary = 2000000;
            bodyHeight = 170.2f;

            Console.WriteLine(employeeCode + "\t|" +
                employeeName + "\t|" +
                startWorking.ToString("yyyy-MM-dd") + "\t|" +
                (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja") + "\t|" +
                salary + "\t|" +
                bodyHeight + "\t|");



            employeeCode = "E004";
            employeeName = "Dwi Putri";
            startWorking = DateTime.Parse("2022-02-11");
            stillWorking = true;
            salary = 3000000;
            bodyHeight = 170.2f;


            //{0}, {1}, ... {5} ..
            //string.Format
            //untuk menformat beberapa tipe data yang beda, menjadi string
            Console.WriteLine(string.Format("{0}\t|{1}\t|{2}\t|{3}\t|{4}\t|{5}\t|",
                employeeCode,
                employeeName,
                startWorking.ToString("yyyy-MM-dd"),
                (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"),
                salary,
                bodyHeight));


            //DateTime startWorking2 = DateTime.Now;
            //Console.WriteLine(string.Format("startWorking2={0}", startWorking2));



            //FORM
            Console.WriteLine("");

            /*
            Format thousand 
            salary.ToString("#,###.00");
            => 1,900.00

            salary.ToString("#,###");
            => 1,900
            */

            Console.WriteLine("=======================================================================================");
            Console.WriteLine("Employee Code\t\t: {0}", employeeCode);
            Console.WriteLine("Employee Name\t\t: {0}", employeeName);
            Console.WriteLine("Start Working\t\t: {0}", startWorking.ToString("yyyy-MM-dd"));
            Console.WriteLine("Still Working\t\t: {0}", (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"));
            Console.WriteLine("Salary\t\t: Rp. {0}", salary.ToString("#,###.00"));
            Console.WriteLine("Body Height\t\t: {0}", bodyHeight.ToString("#,###.00"));
            Console.WriteLine("=======================================================================================");



            employeeCode = "E003";
            employeeName = "Dinda";
            startWorking = DateTime.Parse("2022-02-11");
            stillWorking = true;
            salary = 2000000;
            bodyHeight = 170.35f;
            Console.WriteLine("");

            Console.WriteLine("=======================================================================================");
            Console.WriteLine("Employee Code\t\t: {0}\n" +
                "Employee Name\t\t: {1}\n" +
                "Start Working\t\t: {2}\n" +
                "Still Working\t\t: {3}\n" +
                "Salary\t\t: {4} IDR\n" +
                "Body Height\t\t: {5}\n",

                employeeCode,
                employeeName,
                startWorking.ToString("yyyy-MM-dd"),
                (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"),
                salary.ToString("#,###"),
                bodyHeight.ToString("#,###.00")
                );
            Console.WriteLine("=======================================================================================");



            //mulai input

            /*
            Console.Write("Masukan Employee Code :");
            employeeCode = Console.ReadLine();

            Console.Write("Masukan Employee Name :");
            employeeName = Console.ReadLine();

            Console.Write("Masukan Start Working :");
            string strStartWorking = Console.ReadLine();
            startWorking = DateTime.Parse(strStartWorking);



            Console.Write("Masukan Still Working [Y/N]:");
            string strStillWorking = Console.ReadLine();
            //<string>.ToLower() => jadikan huruf kecil
            strStillWorking = strStillWorking.ToLower();

            if (strStillWorking == "y")
            {
                stillWorking = true;
            }else
            {
                stillWorking = false;
            }


            Console.Write("Masukan Salary:");
            string strSalary = Console.ReadLine();
            salary = Convert.ToDecimal(strSalary);


            Console.Write("Masukan Body Height:");
            string strBodyHeight = Console.ReadLine();
            //float.Parse(mystring, CultureInfo.InvariantCulture.NumberFormat);
            bodyHeight = float.Parse(strBodyHeight);

            Console.WriteLine();
            Console.WriteLine("=======================================================================================");
            Console.WriteLine("Employee Code\t\t: {0}", employeeCode);
            Console.WriteLine("Employee Name\t\t: {0}", employeeName);
            Console.WriteLine("Start Working\t\t: {0}", startWorking.ToString("yyyy-MM-dd"));
            Console.WriteLine("Still Working\t\t: {0}", (stillWorking ? "Masih Bekerja" : "Sudah tidak bekerja"));
            Console.WriteLine("Salary\t\t: Rp. {0}", salary.ToString("#,###.00"));
            Console.WriteLine("Body Height\t\t: {0}", bodyHeight.ToString("#,###.00"));
            Console.WriteLine("=======================================================================================");
            */


            //array 
            string[] employeeCodes = new string[5]
            {
    "E101",
    "E102",
    "E103",
    "E104",
    "E105",
            };

            string[] employeeNames = new string[]
            {
    "Faisal",
    "vido",
    "Dinda",
    "Dwi Putri",
    "Susanto"
            };

            DateTime[] startWorkings = new DateTime[]
            {
    DateTime.Parse("2022-02-01"),
    DateTime.Parse("2022-02-02"),
    DateTime.Parse("2022-02-03"),
    DateTime.Parse("2022-02-04"),
    DateTime.Parse("2022-02-05"),
            };

            bool[] stillWorks = new bool[]
            {
    true,
    false,
    true,
    false,
    true,
            };

            decimal[] salaries = new decimal[]
            {
    1000000,
    2000000,
    3000000,
    4000000,
    5000000,
            };

            float[] heights = new float[]
            {
    150.5f,
    160.5f,
    170.5f,
    175.5f,
    180.5f,
            };


            decimal totalSalaries = 0;
            for (int i = 0; i < employeeCodes.Length; i++)
            {
                Console.WriteLine("{0}\t|{1}\t|{2}\t|{3}\t|{4}\t|{5}\t|",
                    employeeCodes[i],
                    employeeNames[i],
                    startWorkings[i].ToString("yyyy-MM-dd"),
                    (stillWorks[i] ? "Masih Bekerja" : "Sudah tidak bekerja"),
                    salaries[i],
                    heights[i]);

                if (i % 2 == 0)
                {
                    totalSalaries = totalSalaries + salaries[i];
                }
            }
            Console.WriteLine("Length-I={0}", employeeCodes.Length);
            Console.WriteLine("Total Salaries (Genap)={0}", totalSalaries.ToString("#,###"));



            employeeCodes = new string[2];
            employeeNames = new string[2];
            startWorkings = new DateTime[2];
            stillWorks = new bool[2];
            salaries = new decimal[2];
            heights = new float[2];


            employeeCodes[0] = "E201";
            employeeNames[0] = "Faisal";
            startWorkings[0] = DateTime.Parse("2022-02-11");
            stillWorks[0] = true;
            salaries[0] = 1000000;
            heights[0] = 175.8f;

            employeeCodes[1] = "E202";
            employeeNames[1] = "Dinda";
            startWorkings[1] = DateTime.Parse("2022-02-12");
            stillWorks[1] = false;
            salaries[1] = 2000000;
            heights[1] = 165.8f;

            employeeNames[1] = "Dwi Putri";


            Console.WriteLine();

            for (int i = 0; i < employeeCodes.Length; i++)
            {
                Console.WriteLine("{0}\t|{1}\t|{2}\t|{3}\t|{4}\t|{5}\t|",
                    employeeCodes[i],
                    employeeNames[i],
                    startWorkings[i].ToString("yyyy-MM-dd"),
                    (stillWorks[i] ? "Masih Bekerja" : "Sudah tidak bekerja"),
                    salaries[i],
                    heights[i]);


            }

            Console.WriteLine("Length-II={0}", employeeCodes.Length);



        }

        static void accountBalances()
        {
            //tulis coding latihan disini
            Console.WriteLine("tulis coding latihan di sini!");

        }


        static string getListTitle()
        {
            return "DAFTAR KARYAWAN\n";
        }

        static string makeLine(int length, string character, bool newLine)
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                line.Append(character);
            }
            if (newLine)
            {
                line.Append("\n");
            }
            return line.ToString();
        }

        const int ALIGN_LEFT = 1;
        const int ALIGN_RIGHT = 2;

        const int EMPLOYEE_CODE_LENGTH = 20;
        const int EMPLOYEE_NAME_LENGTH = 20;
        const int SALARY_LENGTH = 20;

        static string field(int length, string value, int align, char emptySpace,
            string endDelimiter)
        {
            if (align == ALIGN_LEFT)
            {
                return value.PadRight(length, emptySpace) + endDelimiter;

            }
            else if (align == ALIGN_RIGHT)
            {
                return value.PadLeft(length, emptySpace) + endDelimiter;
            }
            return "";
        }

        static string row(string[] fields)
        {
            StringBuilder _row = new StringBuilder();
            foreach (string field in fields)
            {
                _row.Append(field);
            }
            return _row.Append("\n").ToString();
        }

        static void listEmployeesHeader()
        {
            string[] fields = new string[]
            {
            field(EMPLOYEE_CODE_LENGTH, "Employee Code", ALIGN_LEFT, ' ', "|"),
            field(EMPLOYEE_NAME_LENGTH, "Employee Name", ALIGN_LEFT, ' ', "|"),
            field(SALARY_LENGTH, "Salary", ALIGN_RIGHT, ' ', "|"),
            };

            int totalLength = EMPLOYEE_CODE_LENGTH + EMPLOYEE_NAME_LENGTH + SALARY_LENGTH + 3;

            Console.Write(makeLine(totalLength, "=", true));
            Console.Write(getListTitle());
            Console.Write(makeLine(totalLength, "=", true));
            Console.Write(row(fields));
            Console.Write(makeLine(totalLength, "=", true));

        }
        static void listEmployees(List<string> employeeCodes,
            List<string> employeeNames,
            List<decimal> salaries,
            List<string> currencies
        )
        {

            listEmployeesHeader();

            for (int i = 0; i < employeeCodes.Count; i++)
            {
                string[] fields = new string[]
                {
                field(EMPLOYEE_CODE_LENGTH, employeeCodes[i], ALIGN_LEFT, ' ', "|"),
                field(EMPLOYEE_NAME_LENGTH, employeeNames[i], ALIGN_LEFT, ' ', "|"),
                field(SALARY_LENGTH, salaries[i].ToString("#,###") + " " + currencies[i], ALIGN_RIGHT, ' ', "|"),
                };

                Console.Write(row(fields));

            }

        }

        const int ACTION_ADD_NEW_EMPLOYEE = 1;
        const int ACTION_EDIT_EMPLOYEE = 2;
        const int ACTION_DELETE_EMPLOYEE = 3;
        const int ACTION_EXIT = 4;

        static void actionMenus()
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1. Add New Employee");
            Console.WriteLine("2. Edit Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Exit");

        }

        static string inputEmployeeCode()
        {
            string employeeCode = "";
            while (true)
            {
                Console.Write("Masukan Employee Code :");
                employeeCode = Console.ReadLine();
                if (employeeCode.Length > 0)
                {
                    break;
                }
            }
            return employeeCode;
        }

        static string inputEmployeeName()
        {
            string employeeName = "";
            while (true)
            {
                Console.Write("Masukan Employee Name :");
                employeeName = Console.ReadLine();
                if (employeeName.Length > 0)
                {
                    break;
                }
            }
            return employeeName;

        }

        static decimal inputSalary()
        {
            string strSalary = "";
            decimal salary = 0;
            while (true)
            {
                Console.Write("Masukan Salary :");
                strSalary = Console.ReadLine();
                if (strSalary.Length > 0)
                {
                    try
                    {
                        salary = Convert.ToDecimal(strSalary);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Salary harus angka!");
                    }
                }
            }
            return salary;

        }
        static string inputCurrency()
        {
            string currency = "";
            while (true)
            {
                Console.Write("Masukan Currency :");
                currency = Console.ReadLine();
                if (currency.Length > 0)
                {
                    break;
                }
            }
            return currency;

        }

        static int inputAction()
        {
            string input = Console.ReadLine();
            return int.Parse(input);
        }
        static void conditionalAndLoop()
        {

            List<string> employeeCodes = new List<string>();
            List<string> employeeNames = new List<string>();
            List<decimal> salaries = new List<decimal>();
            List<string> currencies = new List<string>();



            /*List<DateTime> _checkInsByEmployee = new List<DateTime>();
            Dictionary<string, List<DateTime>> checkIns = new Dictionary<string, List<DateTime>>();
            checkIns.Add("E001", _checkInsByEmployee);

            List<DateTime> _checkOutsByEmployee = new List<DateTime>();
            Dictionary<string, List<DateTime>> checkOuts = new Dictionary<string, List<DateTime>>();
            checkOuts.Add("E001", _checkOutsByEmployee);


            foreach (var checkIn in checkIns)
            {
                string employeeCode = checkIn.Key;
                List<DateTime> times = checkIn.Value;
            }*/


            //Add to List
            /*employeeCodes.Add("E001");
            employeeCodes.Add("E002");
            employeeCodes.Add("E003");

            employeeNames.Add("Faisal");
            employeeNames.Add("Dwi Putri");
            employeeNames.Add("Vido");

            salaries.Add(5000000);
            salaries.Add(5500000);
            salaries.Add(600000);

            currencies.Add("IDR");
            currencies.Add("IDR");
            currencies.Add("IDR");

            for (int i = 0; i < employeeCodes.Count; i++)
            {
                Console.WriteLine(employeeCodes[i]);
            }

            foreach (string employeeCode in employeeCodes)
            {
                Console.WriteLine(employeeCode);
            }*/


            bool loop = true;
            while (loop)
            {
                //Console.Clear();
                listEmployees(employeeCodes,
                       employeeNames,
                       salaries,
                       currencies);

                actionMenus();

                var action = inputAction();
                switch (action)
                {
                    case ACTION_ADD_NEW_EMPLOYEE:

                        var employeeCode = inputEmployeeCode();
                        var employeeName = inputEmployeeName();
                        var salary = inputSalary();
                        var currency = inputCurrency();

                        employeeCodes.Add(employeeCode);
                        employeeNames.Add(employeeName);
                        salaries.Add(salary);
                        currencies.Add(currency);

                        break;

                    case ACTION_EDIT_EMPLOYEE:
                        Console.WriteLine("Your Action is Edit Employee");
                        Console.ReadLine();
                        break;

                    case ACTION_DELETE_EMPLOYEE:
                        Console.WriteLine("Your Action is Delete Employee");
                        Console.ReadLine();
                        break;

                    case ACTION_EXIT:
                        loop = false;
                        break;

                }


            }


        }

        static void learnDictionary()
        {
            Dictionary<string, string> employeeNames = new Dictionary<string, string>();
            employeeNames.Add("E001", "Faisal");
            employeeNames.Add("E002", "Vido");
            employeeNames.Add("E003", "Dwi Putri");

            Dictionary<string, decimal> salaries = new Dictionary<string, decimal>();
            salaries.Add("E001", 1000);
            salaries.Add("E002", 2000);
            salaries.Add("E003", 3000);


            Console.Write(makeLine(20, "=", true));
            Console.WriteLine("Tanya Berapa Gaji");
            Console.Write(makeLine(20, "=", true));
            Console.Write("Masukkan Employee Code:");

            string employeeCode = Console.ReadLine();
            var hasKey = salaries.ContainsKey(employeeCode);
            if (hasKey)
            {
                string[] fields = new string[]
                {
                field(EMPLOYEE_CODE_LENGTH, employeeCode, ALIGN_LEFT, ' ', "|" ),
                field(EMPLOYEE_NAME_LENGTH, employeeNames[employeeCode], ALIGN_LEFT, ' ', "|" ),
                field(SALARY_LENGTH, salaries[employeeCode].ToString("#,###"), ALIGN_RIGHT, ' ', "|" ),
                };
                Console.Write(row(fields));
            }
            else
            {
                Console.WriteLine("Employye Code Not Found");

            }
        }

        static void searchEmployeeArr()
        {
            List<string> employeeCodes = new List<string>();
            employeeCodes.Add("E001");
            employeeCodes.Add("E002");
            employeeCodes.Add("E003");

            List<string> employeeNames = new List<string>();
            employeeNames.Add("Faisal");
            employeeNames.Add("Dwi Putri");
            employeeNames.Add("Vido");

            Console.Write("Cari Karyawan. Masukkan Employee Code:");
            var empCode = Console.ReadLine();

            var foundIndex = -1;
            for (int i = 0; i < employeeCodes.Count; i++)
            {
                if (employeeCodes[i] == empCode)
                {
                    foundIndex = i;
                    break;

                }
            }

            if (foundIndex > -1)
            {
                Console.WriteLine("Employee Name:{0}", employeeNames[foundIndex]);
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }


        const int MAX_SALARIES = 6;
        const int MAX_NAMES = 5;
        const int MAX_DATES = 5;
        const int SORT_TYPE_ASC = 1;
        const int SORT_TYPE_DESC = 2;


        static void printSalaries(float[] salaries)
        {
            for (int i = 0; i < MAX_SALARIES; i++)
            {
                Console.WriteLine("Salaries[{0}]={1}", (i + 1), salaries[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void printNames(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine("Names[{0}]={1}", (i + 1), names[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void printDates(DateTime[] dates)
        {
            for (int i = 0; i < MAX_DATES; i++)
            {
                Console.WriteLine("dates[{0}]={1}", (i + 1), dates[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static float[] initSalaries()
        {
            float[] salaries = new float[6];
            Random r = new Random();
            for (int i = 0; i < MAX_SALARIES; i++)
            {
                salaries[i] = r.Next(1000, 10000);
            }

            return salaries;

        }


        //bubble sort
        static float[] sortingSalaries(float[] salaries, int sortType)
        {
            for (int i = 0; i < MAX_SALARIES - 1; i++)
            {
                for (int j = i + 1; j < MAX_SALARIES; j++)
                {
                    if (sortType == SORT_TYPE_ASC)
                    {
                        if (salaries[i] > salaries[j])
                        {
                            var lower = salaries[j];
                            salaries[j] = salaries[i];
                            salaries[i] = lower;

                        }
                    }
                    else if (sortType == SORT_TYPE_DESC)
                    {
                        if (salaries[i] < salaries[j])
                        {
                            var higher = salaries[j];
                            salaries[j] = salaries[i];
                            salaries[i] = higher;

                        }
                    }
                }
            }
            return salaries;
        }



        //bubble sort
        static string[] sortingNames(string[] names, int sortType)
        {
            for (int i = 0; i < MAX_NAMES - 1; i++)
            {
                for (int j = i + 1; j < MAX_NAMES; j++)
                {
                    if (sortType == SORT_TYPE_ASC)
                    {
                        if (names[i].CompareTo(names[j]) > 0)
                        {
                            var lower = names[j];
                            names[j] = names[i];
                            names[i] = lower;

                        }
                    }
                    else if (sortType == SORT_TYPE_DESC)
                    {
                        if (names[i].CompareTo(names[j]) < 0)
                        {
                            var higher = names[j];
                            names[j] = names[i];
                            names[i] = higher;

                        }
                    }
                }
            }
            return names;
        }

        static DateTime[] sortingDates(DateTime[] dates, int sortType)
        {
            for (int i = 0; i < MAX_DATES - 1; i++)
            {
                for (int j = i + 1; j < MAX_DATES; j++)
                {
                    if (sortType == SORT_TYPE_ASC)
                    {
                        if (dates[i] > dates[j])
                        {
                            var lower = dates[j];
                            dates[j] = dates[i];
                            dates[i] = lower;

                        }
                    }
                    else if (sortType == SORT_TYPE_DESC)
                    {
                        if (dates[i] < dates[j])
                        {
                            var higher = dates[j];
                            dates[j] = dates[i];
                            dates[i] = higher;

                        }
                    }
                }
            }
            return dates;
        }


        static string[] initNames()
        {
            return new string[]{
            "Faisal",
            "Vido",
            "Dwi Putri",
            "Fathan",
            "Nery"
        };
        }

        static DateTime[] initDates()
        {
            return new DateTime[]{
            DateTime.Parse("2022-02-16 08:00:00"),
            DateTime.Parse("2022-02-16 09:15:00"),
            DateTime.Parse("2022-02-16 07:30:00"),
            DateTime.Parse("2022-02-16 10:45:00"),
            DateTime.Parse("2022-02-16 06:10:00"),

        };
        }
        static void belajarArray()
        {
            /*
            float[] salaries = initSalaries();
            printSalaries(salaries);


            salaries = sortingSalaries(salaries, SORT_TYPE_DESC);
            Console.WriteLine("AFTER SORTING DESC");
            printSalaries(salaries);


            salaries = sortingSalaries(salaries, SORT_TYPE_ASC);
            Console.WriteLine("AFTER SORTING ASC");
            printSalaries(salaries);


            string[] names = initNames();
            names = sortingNames(names, SORT_TYPE_DESC);
            printNames(names);
            */

            DateTime[] dates = initDates();
            dates = sortingDates(dates, SORT_TYPE_ASC);
            printDates(dates);

        }

        static string[] sequentialSearchString(string[] names, string keyword)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().Contains(keyword.ToLower()))
                {
                    results.Add(names[i]);
                }
            }
            return results.ToArray();
        }

        static void belajarSearch()
        {
            string[] names = initNames();
            string[] results = sequentialSearchString(names, "I");
            printNames(results);
        }

        static void belajarClass()
        {
            services.EmployeeService employeeService = new services.EmployeeService();
            employeeService.AddEmployee(
                "E001",
                "Faisal",
                "2022-02-16",
                true,
                1000,
                "USER001", 
                "faisal@gmail.com",
                "123",
                models.UserType.EMPLOYEE);

            employeeService.AddEmployee(
               "E002",
                "Vido",
                "2022-02-17",
                false,
                2000,
                "USER002",
                "vido@gmail.com",
                "123",
                models.UserType.ADMIN);

            employeeService.PrintConsole(employeeService.Employees.ToArray());

            models.Employee[] results = employeeService.SearchEmployees("001");

            Console.WriteLine("Search Results");
            employeeService.PrintConsole(results);

        }

        static void printStrings(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine("strings[{0}]={1}", (i + 1), strings[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void belajarSplitStrings()
        {

            string salam = "Selamat Pagi Pagi bapak / ibu, ada yang bisa dibantu ?";
            string[] dialogs = salam.Split(" ");
            printStrings(dialogs);


            bool found = false;
            int cnt = 0;
            foreach(string d in dialogs)
            {
                if(d.ToLower()=="pagi")
                {
                    found = true;
                    cnt++;
                }
            }
            if(!found) { 
                Console.WriteLine("tidak ada");
            } else
            {
                Console.WriteLine("ada={0}", cnt);
            }

        }


    }
}
