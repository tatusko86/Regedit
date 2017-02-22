using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Filter
    {
        public string gospodarski(string value)
        { 
            return protectGospodar(value);
        }

        private string protectGospodar(string resulUr)
        {

            resulUr = resulUr.Replace("&quot;", "\"");
            resulUr = resulUr.Replace("&nbsp;", " ");
            resulUr = resulUr.Replace("&#171;", "\"");
            resulUr = resulUr.Replace("&#187;", "\"*");
            resulUr = resulUr.Replace(":", "*");
            resulUr = resulUr.Replace("</P>", "*");
            resulUr = resulUr.Replace("</p>", "*");
            resulUr = resulUr.Replace("</span><span align=\"justify\" style=\"background-color*#FFFFFF;font-family*Times New Roman CYR;font-size*13pt;\">", " ");
            resulUr = resulUr.Replace("</span><span align=\"justify\" style=\"background-color*#FFFFFF;font-family*Times New Roman CYR;font-size*12pt;\">", "`");
            resulUr = resulUr.Replace("</span>", "*");
            resulUr = resulUr.Replace("* *", " ");
            resulUr = resulUr.Replace("**", "*");

            resulUr = resulUr.Replace("&#39;", "`");
            resulUr = resulUr.Replace("        ", " ");
            resulUr = resulUr.Replace("      ", " ");
            resulUr = resulUr.Replace("     ", " ");
            resulUr = resulUr.Replace("   ", " ");
            resulUr = resulUr.Replace("  ", " ");
            resulUr = resulUr.Replace("  ", " ");
            resulUr = resulUr.Replace("  ", " ");
            resulUr = resulUr.Replace("  ", " ");

            bool bWriteflag = true;
            System.Text.StringBuilder sbRezHtml = new System.Text.StringBuilder();



            for (int i = 0; i < resulUr.Length; i++)
            {
                char c = resulUr[i];
                if (c == '<') { bWriteflag = false; continue; }
                else if (c == '>') { bWriteflag = true; continue; }

                if (bWriteflag) { sbRezHtml.Append(c); }
                //Process char
            }

            resulUr = sbRezHtml.ToString().ToUpper();
            resulUr = resulUr.Replace("* *", " ");
            resulUr = resulUr.Replace("**", "*");
            resulUr = resulUr.Replace("1.", "*");
            resulUr = resulUr.Replace("2.", "*");
            resulUr = resulUr.Replace("**", "*");
            resulUr = resulUr.Replace("  ", " ");
            resulUr = resulUr.Replace("  ", " ");
            resulUr = resulUr.Replace("ПРО* СТЯГНЕННЯ", "ПРО СТЯГНЕННЯ*");
            resulUr = resulUr.Replace("ПРО *СТЯГНЕННЯ", "ПРО СТЯГНЕННЯ*");
            resulUr = resulUr.Replace("ПРО * СТЯГНЕННЯ", "ПРО СТЯГНЕННЯ*");
            resulUr = resulUr.Replace("ПРО*СТЯГНЕННЯ", "ПРО СТЯГНЕННЯ*");
            resulUr = resulUr.Replace("**", "*");
            resulUr = resulUr.Replace("ПРО *", "ПРО*");
            resulUr = resulUr.Replace("ДО *", "ДО*");
            resulUr = resulUr.Replace("1*", "1");
            resulUr = resulUr.Replace("2*", "2");
            resulUr = resulUr.Replace("3*", "3");
            resulUr = resulUr.Replace("4*", "4");
            resulUr = resulUr.Replace("5*", "5");
            resulUr = resulUr.Replace("6*", "6");
            resulUr = resulUr.Replace("7*", "7");
            resulUr = resulUr.Replace("8*", "8");
            resulUr = resulUr.Replace("9*", "9");
            resulUr = resulUr.Replace("0*", "0");

            return resulUr;
        }
    }



}
