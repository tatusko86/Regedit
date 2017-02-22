using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegeditS
{
    class ParsSprav
    {
        private string pozivach;
        private string vidpovidach;
        private string abzac;
        private string sumPozov;
        private string Href;
        private Sprava sprava = new Sprava();

        //Данный метод должен возврашяеть класс Sprava
        public Sprava parsGospodar(string href)
        {
            Href = href;
            gospodarski(link(href));
            

            sprava.Type = "Господарське";
            sprava.Pozivach = pozivach;
            sprava.Vidpovidach = vidpovidach;
            sprava.Sum = sumPozov;
            sprava.Href = Href;

            return sprava;
        }



        private string link(string href)
        {
            string resulUr="";
            try
            {
                //Идем конкретно к судебному решению 
                CookieContainer cookie = new CookieContainer();
                HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create("http://www.reyestr.court.gov.ua" + href);
                cookie = request1.CookieContainer;
                HttpWebResponse respore1 = (HttpWebResponse)request1.GetResponse();
                Stream st = respore1.GetResponseStream();
                StreamReader sr = new StreamReader(st);

                resulUr = sr.ReadToEnd();

                sr.Close();
            }
            catch { return "Error"; }
            // Создаем обьект фильтер 
            Filter f = new Filter();

            // Возвращаем отфильтрованный текст
            return f.gospodarski(resulUr);
           
        }

        private void gospodarski(string html)
        {
            // Создаем ключевые слова
            string zaPozovom = "ЗА ПОЗОВОМ";
            string zaPozovom2 = "ЗА ПОЗОВНОЮ ЗАЯВОЮ";

            string doVidpovidacha = "ДО ВІДПОВІДАЧА";

            string proStagnenya = "ПРО СТЯГНЕННЯ";
           
            string stagnennya = "СТЯГНЕННЯ";

            string do1 = "ДО *";
            string do12 = "ДО*";
            string do123 = "ДО ";

            string pro1 = "ПРО *";
            string pro12 = "ПРО*";
            string pro123 = "ПРО ";


            // отрезаем лишний текст  
            try
            {
                char[] r = html.ToCharArray();
                int index1 = html.IndexOf("ЄДИНИЙ ДЕРЖАВНИЙ РЕЄСТР СУДОВИХ РІШЕНЬ");
                int index2 = html.IndexOf("ЄДИНИЙ ДЕРЖАВНИЙ РЕЄСТР СУДОВИХ РІШЕНЬ", index1 + 20);
                String g = new String(r, index2, r.Length - index2);
                html = g;

            }
            catch { }
            

            // Получаем индексы ключевых слов
            int indexStagnennya = html.IndexOf(stagnennya);
            int indexZaPozovom = html.IndexOf(zaPozovom);
            int indexZaPozovom2 = html.IndexOf(zaPozovom2);
            int indexDoVidpovidacha = html.IndexOf(doVidpovidacha);
            int indexProStagnenya = html.IndexOf(proStagnenya);
            int indexDo = html.IndexOf(do1);
            int indexPro = html.IndexOf(pro1);
            int indexDo2 = html.IndexOf(do12);
            int indexPro2 = html.IndexOf(pro12);
            int indexPro3 = html.IndexOf(pro123);
            int indexDo3 = html.IndexOf(do123);

           
            // И тут начинается извращение ))) (Логика отпоба ключевых слов)

            try
            {
                if (indexZaPozovom == -1)
                    pozivach = getResult(indexZaPozovom2, html);
                else
                {
                    pozivach = getResult(indexZaPozovom, html);
                }

                // Do kogo?

                if (indexDo2 != -1)
                {
                    vidpovidach = getResult(indexDo2, html);

                }


                else
                {

                    if (indexDoVidpovidacha == -1)
                    {
                        if (indexDo == -1)

                            if (indexDo2 == -1)
                                vidpovidach = getResult(indexDo3, html);
                            else
                                vidpovidach = getResult(indexDo2, html);


                        else
                            vidpovidach = getResult(indexDo, html);
                    }
                    else { vidpovidach = getResult(indexDoVidpovidacha, html); }


                }
                

                //Styagnennya "PRO"
                if (indexPro2 != -1)
                { sumPozov = getResult(indexPro2, html); }

                else
                {

                    if (indexProStagnenya == -1)
                    {
                        if (indexPro == -1)

                            if (indexPro2 == -1)
                                sumPozov = getResult(indexPro3, html);
                            else
                                sumPozov = getResult(indexPro2, html);

                        else
                            sumPozov = getResult(indexPro, html);
                    }
                    else
                    {
                        sumPozov = getResult(indexProStagnenya, html);
                    }

                }

            }

            catch
            {
                sumPozov = getResult(indexStagnennya, html);

            }
          
        }
        // данный метод отвечает за нахождение интересующих нами слов
        private string getResult(int index, string html)

        {
            try
            {

                string result = "";
                char[] ch = html.ToCharArray();

                for (int x = index; x < index + 30; x++)
                {
                    if (ch[x] == '*')
                    {
                        while (true)
                        {
                            x++;
                            if (ch[x] == 'Г' && ch[x + 1] == 'Р' && ch[x + 2] == 'Н' && ch[x + 3] == '.')
                            {
                                result += ch[x];
                                result += ch[x + 1];
                                result += ch[x + 2];
                                result += ch[x + 3];
                                break;
                            }
                            if (ch[x] == '*' | ch[x] == '\r') break;
                            result += ch[x];

                        }

                    }
                }

                if (result == "")
                {
                    for (int x = index; x < index + 1000; x++)
                    {
                        if (ch[x] == '*') break;
                        if (ch[x] == 'Г' && ch[x + 1] == 'Р' && ch[x + 2] == 'Н' && ch[x + 3] == '.') break;
                        result += ch[x];
                    }

                }

                return result;
            }



            catch { return "http://www.reyestr.court.gov.ua"+Href; }



        }

    }
}
