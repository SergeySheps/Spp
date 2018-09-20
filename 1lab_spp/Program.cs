using System;
using System.Collections.Generic;
using System.Threading;
using ClassLibrary1lab_spp;

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

            var jsonSerializer = new JsonCustomSerializer();
            var jsonSerializedText = jsonSerializer.Serialize(tracer.GetTraceResult());

            var xmlSerializer = new XmlSerializer();
            var xmlSerializedText = xmlSerializer.Serialize(jsonSerializedText);

            var outputResult = new FileOutput();

            outputResult.OutputData(jsonSerializedText, ".json");
            outputResult.OutputData(xmlSerializedText, ".xml");

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
            Thread.Sleep(200);

            tracer.StopTrace();
        }

    }
}
