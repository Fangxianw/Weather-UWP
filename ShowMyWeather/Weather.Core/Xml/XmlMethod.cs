using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Weather.Core.Xml
{
    public class XmlMethod
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="xml">xml</param>
        /// <param name="model">model</param>
        /// <returns></returns>
        public static T XmlToModel<T>(string xml, T model)
        {
            StringReader xmlReader = new StringReader(xml);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            return (T)xmlSer.Deserialize(xmlReader);
        }
    }
}