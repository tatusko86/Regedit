using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Blank 
    { 
        private string type;
        private string number;
        private string data;
        private string href;

       // private List <Blank> blank;
        

        public string Type { set { type = value; } get { return type; } }
        public string Number { set { number = value; } get { return number; } }
        public string Data { set { data = value; } get { return data; } }
        public string Href { set { href = value; } get { return href; } }
       // public List<Blank> blank1 { set { blank = value; } get { return blank; } }

    }
}
