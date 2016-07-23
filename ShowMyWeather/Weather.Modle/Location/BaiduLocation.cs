namespace Weather.Modle.Location
{
    /// <summary>
    /// 详细位置信息
    /// </summary>
    public class AddressComponent
    {
        /// <summary>
        /// 城市名
        /// </summary>
        public string city { get; set; }

        /// <summary>
        ///和当前坐标点的方向
        /// </summary>
        public string direction { get; set; }

        /// <summary>
        ///离坐标点距离
        /// </summary>
        public string distance { get; set; }

        /// <summary>
        /// 区县名
        /// </summary>
        public string district { get; set; }

        /// <summary>
        ///省名
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 街道名
        /// </summary>
        public string street { get; set; }

        /// <summary>
        /// 街道门牌号
        /// </summary>
        public string street_number { get; set; }
    }

    /// <summary>
    /// 百度位置信息
    /// </summary>
    public class BaiduLocation
    {
        /// <summary>
        /// 结果
        /// </summary>
        public Result result { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
    }

    /// <summary>
    /// 经纬度
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 纬度值
        /// </summary>
        public float lat { get; set; }

        /// <summary>
        /// 经度值
        /// </summary>
        public float lng { get; set; }
    }

    /// <summary>
    /// 结果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 位置信息
        /// </summary>
        public AddressComponent addressComponent { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string business { get; set; }

        /// <summary>
        ///城市代码
        /// </summary>
        public int cityCode { get; set; }

        /// <summary>
        /// 结构化地址信息
        /// </summary>
        public string formatted_address { get; set; }

        /// <summary>
        /// 经纬度
        /// </summary>
        public Location location { get; set; }
    }
}