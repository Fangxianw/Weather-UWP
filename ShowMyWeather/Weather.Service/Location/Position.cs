using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Weather.Core;
using Weather.Core.Json;
using Weather.Modle.Location;
using Weather.Service.Http;

namespace Weather.Service.Location
{
    public class Position : IPosition
    {
        private readonly IMHttp _http = new MHttp();

        /// <summary>
        /// 经纬度解析
        /// </summary>
        /// <param name="Longitude">精度</param>
        /// <param name="Latitude">纬度</param>
        /// <param name="CallType">响应方式</param>
        public BaiduLocation Getdistrict(string Longitude, string Latitude, string CallType)
        {
            var url = "http://api.map.baidu.com/geocoder";
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("location", Latitude + "," + Longitude);//维度加精度
            parameters1.Add("output", CallType);
            parameters1.Add("key", "8K08CxWScbFV7BKKarcevPq9LWBaVAUj");
            var result = _http.HttpSend(url, parameters1, "post");
            var baiduResult = JsonMethod.JsonToModel<BaiduLocation>(result);
            return baiduResult;
        }
    }
}