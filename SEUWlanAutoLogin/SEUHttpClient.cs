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
        /// 
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
        /// 检查当前校园网登录状态
        /// </summary>
        /// <returns>如果未登录，User的ID为0</returns>
        public async Task<SEUUser> CampusNetIsLogin()
        {
            
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
            //if(myResponseJson.error == null) // authen success
            //{
            //    return true;
            //}
            //else
            //{ return false; }
        }
        public async Task<bool> CampusNetLogout()
        {

        }

    }
}
