using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System.IO;
using HtmlAgilityPack;

namespace RegeditS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //03449083
            InBlank sdsdsd = new InBlank();
            string[] ss = new string[] { "03449083" };
            Agent[] agent= sdsdsd.start(ss);
            HtmlTable table = new HtmlTable();
            Save save = new Save();
            string result1 =  table.header();

            for (int t=0;t<agent.Length;t++)
            {
                for (int u = 0; u < agent[t].Sprava.Length; u++)
                {
                     table.set(agent[t].Blank[u].Data,agent[t].Sprava[u].Pozivach, agent[t].Sprava[u].Vidpovidach, agent[t].Sprava[u].Sum);
                    result1 += table.start2();
                    
                }



            }
           
            result1 += table.podval();
            save.html(result1);
            



            //----------------------------------------------------
            


            string s = "28.12.2016";
            string patern = "dd - MM - yyyy";


            DateTime data = Convert.ToDateTime(s);
            DateTime data1 =  DateTime.Now;

            string html;
            if (data <= data1)
            label1.Text = data.ToString();

          
            StreamReader str = new StreamReader("1.txt");

            html = str.ReadToEnd();
            str.Close();



            string result="";
           
            int i=0;

            List<string> hrefTags = new List<string>();
         
            var parser = new HtmlParser();
            var document = parser.Parse(html);

            var result2 = document.QuerySelectorAll("a");



            foreach (IElement element in document.QuerySelectorAll("a"))
            {
                hrefTags.Add(element.GetAttribute("href"));               
                result += hrefTags[i];
                

                i++;
            }


            // Создаём экземпляр класса
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            // Присваиваем текстовой переменной k html-код
           // string k = "<html><head><title>Пример 1</title></head> <body> <div class=\"bla1\"><img src=\"https://www.google.ru/images/srpr/logo3w.png\"/>типа изображение</div></body> </html>";
            // Загружаем в класс (парсер) наш html
            doc.LoadHtml(html);
            // Извлекаем значения
            HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//td[@class='CaseNumber tr1']");
            // Выводим на экран значиение атрибута src
            // у изображения, которое находилось
            // в теге <div> в слассом bla
            //string ff = bodyNode.InnerText;
            //string ff = bodyNode.Attributes["src"].Value;
            string ff = "";
            foreach (var w in doc.DocumentNode.SelectNodes("//td[@class='CaseNumber tr1']"))
            {
                ff += w.InnerText;
            }

           

            ff +="  ";
            var wg = doc.DocumentNode.SelectNodes("//td[@class='CaseNumber tr1']");

            label1.Text = result;

        }
    }
}
