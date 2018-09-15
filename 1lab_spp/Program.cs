using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary1lab_spp;

namespace _1lab_spp
{
    class Program
    {
        private static Tracer tracer; 
        //private static List<Thread> _threads;

        static void Main()
        {
            //_threads = new List<Thread>();
            tracer = new Tracer();
            //MultipleThreadMethod();
            //string serialize = JsonConvert.SerializeObject(_tracer.TraceResult, Formatting.Indented);
            //File.WriteAllText("result.txt", serialize);
            //Console.WriteLine(serialize);
            SomeMethod();
            
            Console.ReadLine();
        }

        private static void SomeMethod()
        {
            Thread.Sleep(1000);
            tracer.StartTrace();
            Thread.Sleep(1000);

            tracer.StopTrace();
        }

    }
}
