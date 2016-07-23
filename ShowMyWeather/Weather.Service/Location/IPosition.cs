using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Modle.Location;

namespace Weather.Service.Location
{
    public interface IPosition
    {
        /// <summary>
        /// 经纬度解析
        /// </summary>
        /// <param name="Longitude">精度</param>
        /// <param name="Latitude">纬度</param>
        /// <param name="CallType">响应方式</param>
        BaiduLocation Getdistrict(string Longitude, string Latitude, string CallType);
    }
}