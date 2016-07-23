using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Http
{
    public interface IMHttp
    {
        string HttpSend(string url, Dictionary<string, string> key_value, string method);
    }
}