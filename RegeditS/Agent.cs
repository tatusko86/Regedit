using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Agent 
    {
        private string name;
        private string okpo;
        private Blank[] blank;
        private Sprava[] sprava;

        public string Name { set { name = value; } get { return name; } }
        public string OKPO { set { okpo = value; } get { return okpo; } }
        public Blank[] Blank { set { blank = value; } get { return  blank; } }
        public Sprava[] Sprava { set { sprava = value; } get { return sprava; } }
        public void Ublank(int value) { blank = new Blank [value]; }

    }
}
