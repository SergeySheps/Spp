using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClassLibrary1lab_spp;
using System.IO;

namespace _1lab_spp
{
    class Program
    {
        private static Tracer tracer; 
        private static List<Thread> threads;

        static void Main()
        {
            threads = new List<Thread>();
            tracer = new Tracer();
            MultipleThreadMethod();
            string serialize = JsonConvert.SerializeObject(tracer.GetTraceResult(), Formatting.Indented);
            //File.WriteAllText("result.txt", serialize);
            Console.WriteLine(serialize);
            Console.ReadLine();
            //TestMethod();
            
            Console.ReadLine();
        }

        private static void MultipleThreadMethod()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private static void TestMethod()
        {
            tracer.StartTrace();
            Thread.Sleep(1000);

            tracer.StopTrace();
        }

    }
}
