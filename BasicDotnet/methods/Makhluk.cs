using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.methods
{
   
    public class Makhluk
    {
        private int _nyawa = 0;

        /*
         * <access_priviledge> <data_type> <nama_method>(){ 
         * }
         * 
         * data type:
         * 
         * =========================
         * void => tidak ada return
         * ------------------------
         * 
         * ==============
         * native:
         * ---------------
         *  - int
         *  - string
         *  - float
         *  - decimal
         *  - bool
         *  
         *  ================
         *  array:
         *  ----------------
         *  - int[]
         *  - string[]
         *  - decimal[]
         *  - bool[]
         *  
         *  ===============
         *  list:
         *  ---------------
         *  - List<int>
         *  - List<string>
         *  - List<Makhluk>
         *  
         *  =============
         *  nullable
         *  -------------
         *  Exception?
         *  List<int>?
         *  int?
         *  string?
         */

        public int GetNyawa()
        {
            return _nyawa;
        }

        public int? GetNyawaOrNull()
        {
            if(_nyawa ==0)
            {
                return null;
            } else
            {
                return _nyawa;
            }
        }

        public void CetakNyawa()
        {
            Console.WriteLine("Nyawa={0}", _nyawa);
        }

    }
}
