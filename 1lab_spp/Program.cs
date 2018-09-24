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

            var tracerResult = tracer.GetTraceResult();

            var tracerResultList = new List<ThreadResult>();
            tracerResultList.AddRange(tracerResult.ThreadResults.Values);

            var jsonSerializer = new JsonCustomSerializer();
            var jsonSerializedText = jsonSerializer.Serialize(tracerResultList);

            var xmlSerializer = new XmlCustomSerializer();
            var xmlSerializedText = xmlSerializer.Serialize(tracerResultList);

            var fileOutputResult = new FileOutput();
            var consoleOutputResult = new ConsoleOutput();

            fileOutputResult.OutputData(jsonSerializedText, ".json");
            fileOutputResult.OutputData(xmlSerializedText, ".xml");

            consoleOutputResult.OutputData(jsonSerializedText);
            consoleOutputResult.OutputData(xmlSerializedText);

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
