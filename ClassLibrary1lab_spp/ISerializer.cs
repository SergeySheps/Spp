using System.Collections.Generic;

namespace ClassLibrary1lab_spp
{
    interface ISerializer
    {
        string Serialize(List<ThreadResult> value);
    }
}
