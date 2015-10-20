using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;

namespace SEUWlanAutoLogin
{
    class NICHttpClient
    {
        private CookieContainer nicCookieContainer;
        private HttpClientHandler nicHttpHandler;
        private HttpClient nicHttpClient;

        public NICHttpClient()
        {
            nicCookieContainer = new CookieContainer();
            nicHttpHandler = new HttpClientHandler();
            nicHttpHandler.CookieContainer = nicCookieContainer;
            nicHttpClient = new HttpClient(nicHttpHandler);
        }

        /// <summary>
        /// POST方法
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public async Task<string> NICHttpClientPost(Uri uri, FormUrlEncodedContent postData)
        {
            string responseStr;
            try
            {
                HttpResponseMessage respone = await nicHttpClient.PostAsync(uri, postData);
                respone.Content.Headers.ContentType.CharSet = "GBK"; //not fully considered, but works good
                responseStr = await respone.Content.ReadAsStringAsync();
                
            }
            catch
            {
                return "error";
            }
            return responseStr;
        }


        /// <summary>
        /// GET方法
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> NICHttpClientGet(Uri uri)
        {
            string responseStr;
            try
            {
                HttpResponseMessage respone = await nicHttpClient.GetAsync(uri);
                respone.Content.Headers.ContentType.CharSet = "GBK";
                responseStr = await respone.Content.ReadAsStringAsync();
                
            }
            catch
            {
                return "error";
            }
            return responseStr;
        }

        public async Task<bool> CampusLogin(SEUUser aUser)
        {
            Uri uri = new Uri("https://selfservice.seu.edu.cn/selfservice/campus_login.php");
            var postdata = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username",aUser.StuID),
                    new KeyValuePair<string, string>("password",aUser.Pwd)
                });
            string resp = await NICHttpClientPost(uri, postdata);

            //to be implented!!!!!!!!!!!!!
            return true;
        }

        /// <summary>
        /// 返回所有已登录终端的地点，IP，MAC以及总网络使用量
        /// </summary>
        /// <returns></returns>
        public async Task<List<List<string>>> CampusNetUsage() 
        {
            Uri uri = new Uri("https://selfservice.seu.edu.cn/selfservice/service_manage_status_web.php");
            var postdata = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("operation","status"),
                    new KeyValuePair<string, string>("item","web"),
                    new KeyValuePair<string, string>("web_sel","1")
                });
            string resp = await NICHttpClientPost(uri, postdata);

            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(resp);
            HtmlNode rootNode = hd.DocumentNode;
            HtmlNodeCollection nodeList = rootNode.SelectNodes(@"//tr[@class='font_text']");
            //List<HtmlNode> tablelineNodelist = nodeList.Elements("td").ToList(); //每一行
            

            
            List< List<string>> logDetailList = new List<List<string>>();
            int firstIndex = 3;
            int lastIndex = nodeList.Count - 1 ;
            if(lastIndex>=firstIndex)
            {
                for(int i =firstIndex; i<=lastIndex; i++)
                {
                    List<HtmlNode> tmpNodelist = nodeList.ElementAt(i).Elements("td").ToList();
                    List<string> logDetails = new List<string>();
                    foreach(HtmlNode node in tmpNodelist)
                    {
                        logDetails.Add(node.InnerText.Trim());
                    }
                    logDetailList.Add(logDetails);

                }
                
            }

            return logDetailList;
        }
    
    }
}
