using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1lab_spp
{
    interface ISerializer
    {
        string Serialize(object value);
    }
}
