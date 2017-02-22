using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Save
    {
        public void html(string value)
        {
            StreamWriter sw = new StreamWriter("S.html", true, Encoding.GetEncoding("utf-8"));
            sw.WriteLine(value);
            sw.Close();

        }
    }
}
