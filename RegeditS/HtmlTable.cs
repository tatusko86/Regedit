using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class HtmlTable
    {
        string htmlHeader =
                             "<table colspan=\"5\" align=\"center\" border=\"1\" bordercolor=\"LightGray\">" +
                             "<td colspan=\"5\" align=\"center\">" +
                             "<font size=\"7\" face=\"Arial\">Судові рішення</font>" +
                             "</td>" +
                             "</tr>" +
                             "<tr>" +
                             "<td align=\"center\"><font size=\"5\" face=\"Arial\">Дата</font></td>" +
                             "<td align=\"center\"><font size=\"5\" face=\"Arial\">Позивач</font></td>" +
                             "<td align=\"center\"><font size=\"5\" face=\"Arial\">Відповідач</font></td>" +
                             "<td align=\"center\"><font size=\"5\" face=\"Arial\">Суть спору</font></td>" +
                             "<td align=\"center\"><font size=\"5\" face=\"Arial\">Сума</font></td>" +
                             "</tr>";
        List<string> html = new List<string>();

        string htmlPodval = "</table>";
        string gg;



        public void set(string data, string pozivach, string vidpovidach, string sutSporu)
        {
            html.Add("<tr>" +
                     "<td>" + data + "</td>" +
                     "<td>" + pozivach + "</td>" +
                     "<td>" + vidpovidach + "</td>" +
                     "<td>" + sutSporu + "</td>" +
                     "<td>" + sutSporu + "</td>" +
                     "</tr>");

            gg = "<tr>" +
                     "<td>" + data + "</td>" +
                     "<td>" + pozivach + "</td>" +
                     "<td>" + vidpovidach + "</td>" +
                     "<td>" + sutSporu + "</td>" +
                     "<td>" + sutSporu + "</td>" +
                     "</tr>";

        }
        
        // dont work
        public string start()
        {
            string result="";
            foreach (string value in html)
            {
                result += value;
            }

            

            return result;
        }

        public string podval()
        {
            return htmlPodval;
        }
        public string header()
        {
            return htmlHeader;
        }


        public string start2()
        {

            return gg;
        }


        }
}
