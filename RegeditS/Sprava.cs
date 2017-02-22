using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Sprava
    {
        private string type;
        private string pozivach;
        private string vidpovidach;
        private string sum;
        private string abzac;
        private string href;

        private List<string> sumPozov;
        private List <string> ollHref;
        private int ollSum;

        public string Href { set { href = value; } get { return href; } }
        public string Sum { set { sum = value; } get { return sum; } }
        public string Type { set { type = value; } get { return type; } }
        public string Pozivach { set { pozivach = value; } get { return pozivach; } }
        public string Vidpovidach { set { vidpovidach = value; } get { return vidpovidach; } }
        public string Abzac { set { abzac = value; } get { return abzac; } }
        public List<string> SumPozov { set { sumPozov = value; } get { return sumPozov; } }
        public List<string> OllHref { set { ollHref = value; } get { return ollHref; } }

        public void addSum(string sum)
        {
            sumPozov.Add(sum);
        }



        public void summResult()
        {

        }

        private int getSumm(string[]summ)
        {
            return 0;

        }

    }

   

}
