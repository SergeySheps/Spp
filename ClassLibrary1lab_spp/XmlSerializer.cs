using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassLibrary1lab_spp
{
    public class XmlCustomSerializer :ISerializer
    {
        public string Serialize(List<ThreadResult> tracerResultList)
        {
            MemoryStream memoryStream = new MemoryStream();

            var xmlSerializer = new XmlSerializer(typeof(List<ThreadResult>));

            xmlSerializer.Serialize(memoryStream, tracerResultList);
            memoryStream.Position = 0;

            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
