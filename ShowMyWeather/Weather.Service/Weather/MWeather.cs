using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Weather.Core.Json;
using Weather.Core.Xml;
using Weather.Modle.Weather;
using Weather.Service.Http;

namespace Weather.Service.Weather
{
    public class MWeather : IMWeather
    {
        private readonly IMHttp _http = new MHttp();

        /// <summary>
        /// 根据名称获取天气
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public WeatherInfo GetWeatherInfo(string cityName)
        {
            var url = "http://wthrcdn.etouch.cn/WeatherApi";
            var parameters2 = new Dictionary<string, string>();
            parameters2.Add("city", cityName);
            var weatherXML = _http.HttpSend(url, parameters2, "post").ToString();
            var weatherInfo = new WeatherInfo();
            var doc = new XmlDocument();
            doc.LoadXml(weatherXML);
            var weatherJson = JsonMethod.XmlToJSON(doc);
            weatherInfo = JsonMethod.JsonToModel<WeatherInfo>(weatherJson);

            return weatherInfo;
        }
    }
}