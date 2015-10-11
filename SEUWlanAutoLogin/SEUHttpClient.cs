using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;


namespace SEUWlanAutoLogin
{
    class SEUHttpClient
    {
        private CookieContainer cookieContainer;
        private HttpClientHandler seuHttpHandler;
        private HttpClient seuHttpClient;

        public SEUHttpClient()
        {
            cookieContainer = new CookieContainer();
            seuHttpHandler = new HttpClientHandler();
            seuHttpHandler.CookieContainer = cookieContainer;
            seuHttpClient = new HttpClient(seuHttpHandler);
        }

        /// <summary>
        /// POST方法
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public async Task<string> SEUHttpClientPost(Uri uri, FormUrlEncodedContent postData)
        {
            string responseStr;
            try
            {
                HttpResponseMessage respone = await seuHttpClient.PostAsync(uri, postData);
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
        public async Task<string> SEUHttpClientGet(Uri uri)
        {
            string responseStr;
            try
            {
                HttpResponseMessage respone = await seuHttpClient.GetAsync(uri);
                responseStr = await respone.Content.ReadAsStringAsync();
            }
            catch
            {
                return "error";
            }
            return responseStr;
        }
        /// <summary>
        /// 检查当前校园网登录状态,并返回IP地址和地理位置
        /// </summary>
        /// <returns>如果未登录，User的ID为0</returns>
        public async Task<SEUUser> CampusNetIsLogin()
        {
            Uri uri = new Uri("https://w.seu.edu.cn/portal/init.php");
            string resp = await SEUHttpClientGet(uri);
            var definition = new { login = "" };
            var jsonLogInfo = JsonConvert.DeserializeAnonymousType(resp, definition);
            SEUUser seuUser = new SEUUser();
            if(jsonLogInfo.login != null)
            {
                var definition2 = new { login_username = "", login_ip = "", login_location="" };
                var jsonLogInfo2 = JsonConvert.DeserializeAnonymousType(resp, definition2);
                seuUser.StuID = jsonLogInfo2.login_username;
                seuUser.IpAddr = jsonLogInfo2.login_ip;
                seuUser.Location = jsonLogInfo2.login_location;
            }
            else
            {
                var definition2 = new { login_ip = "", login_location = "" };
                var jsonLogInfo2 = JsonConvert.DeserializeAnonymousType(resp, definition2);
                seuUser.StuID = "0";
                seuUser.IpAddr = jsonLogInfo2.login_ip;
                seuUser.Location = jsonLogInfo2.login_location;
            }
            return seuUser;
            
        }
        /// <summary>
        /// 使用一卡通号和密码进行登录
        /// </summary>
        /// <param name="aUser"></param>
        /// <returns></returns>
        public async Task<SEUAuthJson> CampusNetLogin(SEUUser aUser)
        {
            var postdata = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username",aUser.StuID),
                    new KeyValuePair<string, string>("password",aUser.Pwd)
                });
            Uri uri = new Uri("https://w.seu.edu.cn/portal/login.php");
            string resp = await SEUHttpClientPost(uri, postdata);
            SEUAuthJson myResponseJson = JsonConvert.DeserializeObject<SEUAuthJson>(resp);
            return myResponseJson;
        }
        /// <summary>
        /// 登出校园网
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CampusNetLogout()
        {
            var postdata = new FormUrlEncodedContent( new List<KeyValuePair<string, string>> {});
            Uri uri = new Uri("https://w.seu.edu.cn/portal/logout.php");
            string resp = await SEUHttpClientPost(uri, postdata);
            var definition = new { success = "" };
            var jsonLogInfo = JsonConvert.DeserializeAnonymousType(resp, definition);
            if (jsonLogInfo.success != null) { return true; }
            else { return false; }
        }

    }
}
