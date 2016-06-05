using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace ShowMyWeather.Handle
{
    public class Position_Service
    {
        /// <summary>
        /// 经纬度解析
        /// </summary>
        /// <param name="Longitude">精度</param>
        /// <param name="Latitude">纬度</param>
        public static List<string> Getdistrict(string Longitude, string Latitude)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            //var url = string.Format("http://api.map.baidu.com/geocoder?location={0},{1}&output={2}&key={3}", weidu, jingdu, type, key);
            //XmlReader xml = XmlReader.Create(url);
            var url = "http://api.map.baidu.com/geocoder";
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("location", Latitude + "," + Longitude);//维度加精度
            parameters1.Add("output", "xml");
            parameters1.Add("key", "8K08CxWScbFV7BKKarcevPq9LWBaVAUj");
            var interXML = Http_Service.HttpSend(url, parameters1, "post").ToString();
            /*********************string转Stream*******************************************************************************************************/
            //byte[] arrb = Encoding.UTF8.GetBytes(interXML);
            //MemoryStream stream = new MemoryStream(arrb);
            //XDocument xmlDoc = XDocument.Load(stream);

            //var query = from b in xmlDoc.Elements("GeocoderSearchResponse").Elements().Elements("addressComponent")
            //            select b.Element("city").Value;
            /****************************************************************************************************************************/
            //XNamespace ad = "http://api.map.baidu.com";//命名空间
            XElement root = XElement.Parse(interXML);//字符串转xml元素
            var clist = from theroot in root.Elements().Elements("addressComponent")
                        select new
                        {
                            streetNumber = theroot.Element("streetNumber").Value,//街道号码
                            street = theroot.Element("street").Value,//街道
                            district = theroot.Element("district").Value,//区、县
                            city = theroot.Element("city").Value,//市
                            province = theroot.Element("province").Value//省
                        };
            List<string> list = new List<string>();

            foreach (var v in clist)
            {
                list.Add(v.streetNumber);//0
                list.Add(v.street);//1
                list.Add(v.district);//2
                list.Add(v.city);//3
                list.Add(v.province);//4
            }
            return list;
        }


        public static JObject Getdistrict(string Longitude, string Latitude, string CallType)
        {
            var url = "http://api.map.baidu.com/geocoder";
            var parameters1 = new Dictionary<string, string>();
            parameters1.Add("location", Latitude + "," + Longitude);//维度加精度
            parameters1.Add("output", CallType);
            parameters1.Add("key", "8K08CxWScbFV7BKKarcevPq9LWBaVAUj");
            var result = Http_Service.HttpSend(url, parameters1, "post");
            JObject obj = JObject.Parse(result);
            return obj;
        }
    }
}
