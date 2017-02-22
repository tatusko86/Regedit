using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using AngleSharp.Parser.Html;

namespace RegeditS
{
    class InBlank
    {
        private List<Sprava> sprava = new List<Sprava>();
        public Agent[]  start(string[] okpo)
        {
           return inBlank(okpo);
        }


        private Agent[] inBlank(string[] okpo)
        {
            // Создаём экземпляр класса
            Agent[] agent = new Agent[okpo.Length];
            // Создаём экземпляр класса
            Connect conn = new Connect();
            // Создаём экземпляр класса
            var parser = new HtmlParser();
            // Создаём экземпляр класса
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

           
            for (int x = 0; x < agent.Length; x++)
            {
                // получаем страницу реестра
               string html = conn.connRestr(okpo[x]);
                // закидуем в парсер
                var document = parser.Parse(html);
                doc.LoadHtml(html);
                // парсим
                var date = doc.DocumentNode.SelectNodes("//td[contains(@class, 'RegDate tr')]");
               

                var type = doc.DocumentNode.SelectNodes("//td[contains(@class, 'CSType tr')]");
             

                var number = doc.DocumentNode.SelectNodes("//td[contains(@class, 'CaseNumber tr')]");
    

                var href = doc.DocumentNode.SelectNodes("//a[@class='doc_text2']");
               
                //Создаем обект в массиве
                agent[x] = new Agent();
                // Вносим ОКПО
                agent[x].OKPO = okpo[x];
                //Инецелизируем бланк с заданой длиной.
                agent[x].Ublank(href.Count);
                //заполняем бланк
                for (int i =0; i< href.Count; i++)
                {
                    //Создаем обект в массиве
                    agent[x].Blank[i] = new Blank(); 
                                     
                    string s = date[i].InnerText;
                    s = s.Replace(" ", "");
                    s = s.Replace("\r", "");
                    s = s.Replace("\n", "");
                    agent[x].Blank[i].Data = s;


                    s = type[i].InnerText;
                    s = s.Replace(" ", "");
                    s = s.Replace("\r", "");
                    s = s.Replace("\n", "");
                    agent[x].Blank[i].Type = s;

                    s = number[i].InnerText;
                    s = s.Replace(" ", "");
                    s = s.Replace("\r", "");
                    s = s.Replace("\n", "");
                    agent[x].Blank[i].Number = s;


                    agent[x].Blank[i].Href = href[i].Attributes["href"].Value;
                    
                    // Поиск судембых дел.
                    ParsSprav pars = new ParsSprav();
                    if(agent[x].Blank[i].Type == "Господарське")

                        // Добавляем дела в лист (если оно "Господарське")
                        sprava.Add(pars.parsGospodar(agent[x].Blank[i].Href));
                       // agent[x].Blank[i].Href = href[i].GetAttribute("href");

                }
                // Добавляем в массив полученый результат
                agent[x].Sprava = sprava.ToArray<Sprava>();
            }

            return agent;

        }


    }
}
