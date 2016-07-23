using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Weather.Service;
using Weather.Service.Http;
using Weather.Service.Location;
using Weather.Service.Weather;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ShowMyWeather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly IMHttp _http = new MHttp();
        private readonly IPosition _position = new Position();
        private readonly IMWeather _weather = new MWeather();

        public MainPage()
        {
            this.InitializeComponent();
        }

        //页面加载之前
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// 调用位置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLocation_Click(object sender, RoutedEventArgs e)
        {
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Unspecified:
                    //定位未开启  提示是否跳转到 设置 页面
                    return;

                case GeolocationAccessStatus.Allowed:
                    //允许获取
                    break;

                case GeolocationAccessStatus.Denied:
                    //不允许获取位置信息时 给予提示 然后根据情况选择是否跳转到 设置 界面
                    await Launcher.LaunchUriAsync(new Uri("ms-settings://privacy/location"));
                    return;

                default:
                    break;
            }
            var gt = new Geolocator();
            var position = await gt.GetGeopositionAsync();
            //以前的position.Coordinate.Latitude 方法在UWP中已经过时，不再推荐使用
            //var latiude = position.Coordinate.Latitude;
            var n = position.Coordinate.PositionSource.ToString();
            var Longitude = position.Coordinate.Point.Position.Longitude.ToString();//精度
            var Latitude = position.Coordinate.Point.Position.Latitude.ToString();//纬度
            var Altitude = position.Coordinate.Point.Position.Altitude.ToString();//海拔
            //百度查询位置
            var BaiduLocation = _position.Getdistrict(Longitude, Latitude, "json");
            if (BaiduLocation.status == "OK")
            {
                var district = BaiduLocation.result.addressComponent.district;
                textInfo.Text = district;
                district = district.Substring(0, district.Length - 1);
                Search_Weather(district);
            }
            else
            {
                textInfo.Text = "位置查询失败";
            }
        }

        private void Search_Weather(string cityName)
        {
            var Weather = _weather.GetWeatherInfo(cityName);
        }
    }
}