using System.Collections.Generic;

namespace Weather.Modle.Weather
{
    public class Day
    {
        /// <summary>
        /// 微风级
        /// </summary>
        public string fengli { get; set; }

        /// <summary>
        /// 无持续风向
        /// </summary>
        public string fengxiang { get; set; }

        /// <summary>
        /// 雷阵雨
        /// </summary>
        public string type { get; set; }
    }

    public class Day_1
    {
        /// <summary>
        /// 微风
        /// </summary>
        public string fl_1 { get; set; }

        /// <summary>
        /// 无持续风向
        /// </summary>
        public string fx_1 { get; set; }

        /// <summary>
        /// 多云
        /// </summary>
        public string type_1 { get; set; }
    }

    public class Forecast
    {
        /// <summary>
        ///
        /// </summary>
        public List<WeatherItem> weather { get; set; }
    }

    public class Night
    {
        /// <summary>
        /// 微风级
        /// </summary>
        public string fengli { get; set; }

        /// <summary>
        /// 无持续风向
        /// </summary>
        public string fengxiang { get; set; }

        /// <summary>
        /// 雷阵雨
        /// </summary>
        public string type { get; set; }
    }

    public class Night_1
    {
        /// <summary>
        /// 微风
        /// </summary>
        public string fl_1 { get; set; }

        /// <summary>
        /// 无持续风向
        /// </summary>
        public string fx_1 { get; set; }

        /// <summary>
        /// 阴
        /// </summary>
        public string type_1 { get; set; }
    }

    public class Resp
    {
        /// <summary>
        /// 丰台
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string error { get; set; }

        /// <summary>
        /// 1级
        /// </summary>
        public string fengli { get; set; }

        /// <summary>
        /// 西风
        /// </summary>
        public string fengxiang { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Forecast forecast { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string shidu { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string sunrise_1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string sunset_1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string updatetime { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string wendu { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Yesterday yesterday { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Zhishus zhishus { get; set; }
    }

    public class WeatherInfo
    {
        /// <summary>
        ///
        /// </summary>
        public Resp resp { get; set; }
    }

    public class WeatherItem
    {
        /// <summary>
        /// 23日星期六
        /// </summary>
        public string date { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Day day { get; set; }

        /// <summary>
        /// 高温 34℃
        /// </summary>
        public string high { get; set; }

        /// <summary>
        /// 低温 27℃
        /// </summary>
        public string low { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Night night { get; set; }
    }

    public class Yesterday
    {
        /// <summary>
        /// 22日星期五
        /// </summary>
        public string date_1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Day_1 day_1 { get; set; }

        /// <summary>
        /// 高温 32℃
        /// </summary>
        public string high_1 { get; set; }

        /// <summary>
        /// 低温 26℃
        /// </summary>
        public string low_1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Night_1 night_1 { get; set; }
    }

    public class ZhishuItem
    {
        /// <summary>
        /// 有降水，较不宜晨练，室外锻炼请携带雨具。建议年老体弱人群适当减少晨练时间。
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// 晨练指数
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 较不宜
        /// </summary>
        public string value { get; set; }
    }

    public class Zhishus
    {
        /// <summary>
        ///
        /// </summary>
        public List<ZhishuItem> zhishu { get; set; }
    }
}