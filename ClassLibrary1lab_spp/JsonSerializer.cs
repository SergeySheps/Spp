using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClassLibrary1lab_spp
{
    public class JsonCustomSerializer : ISerializer
    {
        public string Serialize (List<ThreadResult> value)
        {
           return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
