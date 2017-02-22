using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegeditS
{
    class Connect
    {
        public string connRestr(string value)
        {
            string resulUr;
            CookieContainer cookie = new CookieContainer();

            HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create("http://www.reyestr.court.gov.ua");
           
            request1.Host = "www.reyestr.court.gov.ua";
            request1.ContentLength = 0;
            request1.Headers.Add("Cache-Control", "max-age=0");
            request1.Headers.Add("Upgrade-Insecure-Requests", "1");
            request1.Headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
            request1.Headers.Add("Accept-Language", "uk-UA,uk;q=0.8,ru;q=0.6,en-US;q=0.4,en;q=0.2");
            request1.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request1.Method = "get";
            cookie = request1.CookieContainer;
            HttpWebResponse respore1 = (HttpWebResponse)request1.GetResponse();


            HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("http://www.reyestr.court.gov.ua/");
            request2.CookieContainer = cookie;
            request2.Method = "POST";
            request2.Headers.Add("Pragma", "no-cahe");
            request2.Host = "www.reyestr.court.gov.ua";
            request2.Referer = " http://www.reyestr.court.gov.ua/";
            request2.ContentType = "application/x-www-form-urlencoded";


            request2.ContentLength = 0;
            request2.Headers.Add("Cache-Control", "max-age=0");
            request2.Headers.Add("Upgrade-Insecure-Requests", "1");
            request2.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)");
            request2.Headers.Add("Accept-Language", "uk-UA");
            request2.Headers.Add(HttpRequestHeader.Cookie, respore1.Headers["Set-Cookie"]);
            request2.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";



            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1);
            string sQueryString = "SearchExpression="+value+"&UserCourtCode=&ChairmenName=&RegNumber=&RegDateBegin=&RegDateEnd=&ImportDateBegin=&ImportDateEnd=&CaseNumber=&Sort=1&PagingInfo.ItemsPerPage=1000&Liga=true";
            byte[] ByteArr = System.Text.Encoding.GetEncoding(1251).GetBytes(sQueryString);
            request2.ContentLength = ByteArr.Length;
            request2.GetRequestStream().Write(ByteArr, 0, ByteArr.Length);




            HttpWebResponse respore2 = (HttpWebResponse)request2.GetResponse();

            Stream st = respore2.GetResponseStream();
            StreamReader sr = new StreamReader(st);


            resulUr = sr.ReadToEnd();
            sr.Close();


            return resulUr;
        }

    }
}
