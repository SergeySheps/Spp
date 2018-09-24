using System.IO;

namespace ClassLibrary1lab_spp
{
    public class FileOutput : IOutputFile
    {
        public void OutputData(string text, string fileFormat)
        {
            File.WriteAllText("result" + fileFormat, text);
        }
    }
}
