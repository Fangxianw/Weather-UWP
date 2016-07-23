using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Modle.Weather;

namespace Weather.Service.Weather
{
    public interface IMWeather
    {
        /// <summary>
        /// 根据名称获取天气
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        WeatherInfo GetWeatherInfo(string cityName);
    }
}