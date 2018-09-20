using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1lab_spp
{
    public class XmlSerializer :ISerializer
    {
        public string Serialize(object value)
        {
            var doc = JsonConvert.DeserializeXmlNode((string)value);

            return doc.InnerXml;
        }
    }
}
