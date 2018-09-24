using System;

namespace ClassLibrary1lab_spp
{
    public class ConsoleOutput : IOutputConsole
    {
        public void OutputData(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}
