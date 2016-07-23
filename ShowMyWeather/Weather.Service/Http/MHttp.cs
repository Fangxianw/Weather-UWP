using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Http
{
    public class MHttp : IMHttp
    {
        public string HttpSend(string url, Dictionary<string, string> key_value, string method)
        {
            var myClient = new HttpClient();
            var myRequest = new HttpRequestMessage();
            string httpurl = url + "?" + BuildQuery(key_value);
            if (method.ToLower() == "post")
            {
                myRequest = new HttpRequestMessage(HttpMethod.Post, httpurl);
            }
            else if (method.ToLower() == "get")
            {
                myRequest = new HttpRequestMessage(HttpMethod.Get, httpurl);
            }
            else
            {
                throw new Exception("请输入正确方法");
            }
            var response = myClient.SendAsync(myRequest).Result;
            Stream st = response.Content.ReadAsStreamAsync().Result;
            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress);
            }
            StreamReader sr = new StreamReader(st, Encoding.UTF8);
            string s = sr.ReadToEnd();
            return s;
        }

        /// <summary>
        /// 组装文本请求参数,URL编码
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        private static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;
            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;//键
                string value = dem.Current.Value;//值

                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }
                    postData.Append(WebUtility.UrlEncode(name));
                    postData.Append("=");
                    postData.Append(WebUtility.UrlEncode(value));
                    //postData.Append(value);
                    hasParam = true;
                }
            }
            return postData.ToString();
        }
    }
}