using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace HuyangReservation
{
    public static class HttpManager
    {
        /// <summary>
        ///     쿠키 조회
        /// </summary>
        /// <returns></returns>
        public static IList<string> GetCoockie()
        {
            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/main.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Method = "Get";

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            sr.ReadToEnd();

            return theResponse.Headers.GetValues("Set-Cookie");
        }

        /// <summary>
        ///     메인 조회
        /// </summary>
        /// <returns></returns>
        public static string GetMain(string cookie)
        {
            var cookieSplit = cookie.Split(';');

            var httpWRequest = (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/main.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Method = "Get";
            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            return sr.ReadToEnd();
        }

        /// <summary>
        ///     로그인하기
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string Login(string id, string password, string cookie)
        {
            try
            {
                var parameter = string.Format("RSA=&mmberId={0}&mmberPassword={1}", id, password);
                var cookieSplit = cookie.Split(';');

                var httpWRequest =
                    (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/member/memberLogin.action ");
                httpWRequest.Accept = "text/html, application/xhtml+xml, */*";
                httpWRequest.Referer =
                    "http://www.huyang.go.kr/member/memberLogin.action?retUrl=http%3A%2F%2Fwww.huyang.go.kr%3A80%2Freservation%2FreservationSearch.action";
                httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                
                httpWRequest.Headers.Add("Accept-Language", "ko-KR");
                httpWRequest.Headers.Add("DNT", "1");
                httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpWRequest.ContentType = "application/x-www-form-urlencoded";
                httpWRequest.KeepAlive = true;
                httpWRequest.Method = "Post";
                httpWRequest.ContentLength = parameter.Length;
                httpWRequest.CookieContainer = new CookieContainer();

                var split = cookieSplit[0].Split('=');
                httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

                split = cookieSplit[2].Split('=');
                httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

                var sw = new StreamWriter(httpWRequest.GetRequestStream());
                sw.Write(parameter);
                sw.Close();

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream());

                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"로그인 에러");
                return null;
            }
        }

        /// <summary>
        ///     휴양림 조회
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static List<Lodge> GetForestLodge(string cookie)
        {
            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/reservation/reservationMonthSearch.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Method = "Get";

            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            var resultHtml = sr.ReadToEnd();

            const string searchText = "<option value=\"\">휴양림선택</option>";
            var resultText =
                resultHtml.Substring(resultHtml.IndexOf(searchText) + searchText.Length,
                    resultHtml.IndexOf("</select>", resultHtml.IndexOf(searchText)) - resultHtml.IndexOf(searchText))
                    .Trim();

            resultText = resultText.Replace("</select>", "").Trim();

            var sp = resultText.Split('/');
            var lodges = new List<Lodge> {new Lodge {Code = "0", Name = "휴양림선택"}};

            foreach (var s in sp)
            {
                var re = s.Replace("<option value=\"", "");
                re = re.Replace("option>", "");
                re = re.Replace("<", "");
                re = re.Replace("\">", "|");

                if (re != "")
                {
                    var match = re.Split('|');
                    var lodge = new Lodge {Code = match[0], Name = match[1]};
                    lodges.Add(lodge);
                }
            }

            return lodges;
        }

        /// <summary>
        ///     편의시설 조회
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="dprtm"></param>
        /// <returns></returns>
        public static List<Facility> GetFacility(string cookie, string dprtm)
        {
            var parameter = string.Format("dprtm={0}", dprtm);

            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/common/ajax/selectFcltMdCls.action ");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.Headers.Add("DNT", "1");
            httpWRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.KeepAlive = true;

            httpWRequest.Method = "Post";

            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());

            var resultHtml = sr.ReadToEnd();
            resultHtml = resultHtml.Replace("\r\n", "");
            resultHtml = resultHtml.Trim();
            var jObject = JArray.Parse(resultHtml);

            var facilities = (from obj in jObject.Children()
                select
                    new Facility
                    {
                        Code = obj["DEFAULT_CODE"].Value<string>(),
                        Name = obj["CODE_NM"].Value<string>()
                    }).ToList();

            return facilities;
        }

        /// <summary>
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="dprtm"></param>
        /// <param name="fcltMdcls"></param>
        /// <param name="yyyyMM"></param>
        /// <returns></returns>
        public static List<Site> GetSite(string cookie, string dprtm, string fcltMdcls, string yyyyMM)
        {
            var parameter =
                string.Format(
                    "fcltId=&rsrvtQntt=&useBgnDtm={2}01&paramDprtmId=&waitState=&dprtm={0}&fcltMdcls={1}&availMonth={2}",
                    dprtm, fcltMdcls, yyyyMM);

            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/reservation/reservationMonthSearch.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, /*/";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.Headers.Add("DNT", "1");
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.KeepAlive = true;

            httpWRequest.Method = "Post";

            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            var resultHtml = sr.ReadToEnd();

            var startIndex = 0;
            const string startText = "<a href=\"javascript:win_roomInfo('";
            const string endText = "</a>";

            var sites = new List<Site>();
            while (true)
            {
                startIndex = resultHtml.IndexOf(startText, startIndex + 1);
                if (startIndex == -1)
                {
                    break;
                }

                var resultText =
                    resultHtml.Substring(startIndex + startText.Length,
                        resultHtml.IndexOf(endText, startIndex) - startIndex - startText.Length - endText.Length)
                        .Trim();

                if (resultText.Contains("장애인")) continue;

                var splitDatas = resultText.Split('>');
                var site = new Site {Name = splitDatas[1].Trim()};

                var temp1 = splitDatas[0].Split('?');
                var temp2 = temp1[1].Split('&');
                site.Code = temp2[0].Split('=')[1];
                site.FacilityId = temp2[1].Split('=')[1].Replace("');\"", "");

                sites.Add(site);
            }

            return sites;
        }

        /// <summary>
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="fcltId"></param>
        /// <param name="rsrvtQntt"></param>
        /// <param name="yyyMMdd"></param>
        /// <param name="dprtm"></param>
        /// <param name="fcltMdcls"></param>
        /// <returns></returns>
        public static void CheckSite(string cookie, string fcltId, string rsrvtQntt, string yyyMMdd, string dprtm,
            string fcltMdcls)
        {
            var parameter =
                string.Format(
                    "fcltId={0}&rsrvtQntt={1}&useBgnDtm={2}&paramDprtmId={3}&waitState=0&dprtm={3}&fcltMdcls={4}&availMonth={5}",
                    fcltId, rsrvtQntt, yyyMMdd, dprtm, fcltMdcls, yyyMMdd.Substring(0, 6));

            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/reservation/reservationSelect.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, */*";

            httpWRequest.Referer = "http://www.huyang.go.kr/reservation/reservationMonthSearch.action";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.Headers.Add("DNT", "1");
            httpWRequest.Host = "www.huyang.go.kr";
            httpWRequest.Headers.Add("Pragma", "no-cache");

            httpWRequest.Method = "Post";

            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            string resultHtml = sr.ReadToEnd();
        }


        /// <summary>
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="fcltId"></param>
        /// <param name="yyyMMdd"></param>
        /// <param name="rsrvtQntt"></param>
        /// <param name="dprtm"></param>
        /// <returns></returns>
        public static string Booking(string cookie, string fcltId, string yyyMMdd, string rsrvtQntt, string dprtm)
        {
            var parameter =
                string.Format(
                    "fcltId={0}&useBgnDtm={1}&rsrvtQntt={2}&paramDprtmId={3}&fcltDfuseTpcd=01&fcltRsrvtTpcd=01&park1=0&park2=1&park3=0&_park0=on&agreeCheck=Y&setCk=Y",
                    fcltId, yyyMMdd, rsrvtQntt, dprtm);

            var cookieSplit = cookie.Split(';');

            var httpWRequest =
                (HttpWebRequest) WebRequest.Create("http://www.huyang.go.kr/reservation/reservationSelectProc.action");
            httpWRequest.Accept = "text/html, application/xhtml+xml, */*";

            httpWRequest.Referer = "http://www.huyang.go.kr/reservation/reservationSelect.action";
            httpWRequest.Headers.Add("Accept-Language", "ko-KR");
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            httpWRequest.ContentType = "application/x-www-form-urlencoded";
            httpWRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            httpWRequest.ContentLength = parameter.Length;
            httpWRequest.Headers.Add("DNT", "1");
            httpWRequest.Host = "www.huyang.go.kr";
            httpWRequest.Headers.Add("Pragma", "no-cache");

            httpWRequest.Method = "Post";

            httpWRequest.CookieContainer = new CookieContainer();

            var split = cookieSplit[0].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            split = cookieSplit[2].Split('=');
            httpWRequest.CookieContainer.Add(new Cookie(split[0], split[1], "/", "huyang.go.kr"));

            var sw = new StreamWriter(httpWRequest.GetRequestStream());
            sw.Write(parameter);
            sw.Close();

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream());
            var resultHtml = sr.ReadToEnd();

            return resultHtml;
        }
    }
}