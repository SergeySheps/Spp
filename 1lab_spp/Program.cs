using System;
using System.Collections.Generic;
using System.Threading;
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

            var jsonSerializedText = JsonConvert.SerializeObject(tracer.GetTraceResult(), Formatting.Indented);
            var doc = JsonConvert.DeserializeXmlNode(jsonSerializedText);

            File.WriteAllText("result.json", jsonSerializedText);
            File.WriteAllText("result.xml", doc.InnerXml);

            Console.WriteLine(jsonSerializedText);
            Console.WriteLine(doc.InnerXml);

            Console.ReadLine();
        }

        private static void MultipleThreadMethod()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod1);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private static void TestMethod1()
        {
            tracer.StartTrace();
            Thread.Sleep(1000);
            TestMethod2();
            tracer.StopTrace();
        }

        private static void TestMethod2()
        {
            tracer.StartTrace();
            Thread.Sleep(1000);

            tracer.StopTrace();
        }

    }
}
