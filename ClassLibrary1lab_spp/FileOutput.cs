using System;
using System.IO;

namespace ClassLibrary1lab_spp
{
    public class FileOutput : IOutput
    {
        public void OutputData(string text, string fileFormat)
        {
            File.WriteAllText("result" + fileFormat, text);
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}
