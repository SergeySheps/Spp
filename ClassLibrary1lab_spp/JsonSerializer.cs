using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1lab_spp
{
    public class JsonCustomSerializer : ISerializer
    {
        public string Serialize (object value)
        {
           return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
