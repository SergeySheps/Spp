using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1lab_spp;
using System.Collections.Generic;
using System;

namespace Tracer.Tests
{
    [TestClass]
    public class TracerTest
    {
        private TraceResult traceResult;
        private List<Thread> threads;

        [TestInitialize]
        public void Init()
        {
            var tracer = new ClassLibrary1lab_spp.Tracer();
            threads = new List<Thread>();
            MultipleThreadMethod(tracer);
            
            traceResult = tracer.GetTraceResult();
        }

        [TestMethod]
        public void TraceResult_TimeMoreOrEqual100()
        {
            long expected = 100;

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.time;
            Assert.IsTrue(expected <= actual, $"Time should be equal ${expected}ms");
        }

        [TestMethod]
        public void TraceResult_TimeLessOrEqual200()
        {
            long expected = 200;

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.time;

            Assert.IsTrue(expected >= actual, $"Time should be equal ${expected}ms");
        }

        [TestMethod]
        public void TraceResult_MethodName()
        {
            string expected = nameof(TestMethod1);

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].methodName;

            Assert.IsTrue(expected == actual, $"Method name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ClassName()
        {
            string expected = "TracerTest";

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].className;

            Assert.IsTrue(expected == actual, $"Class name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ThreadId()
        {
            var result = true;
            int errorId = 0;

            foreach (var t in threads)
            {
                if (!traceResult.ThreadResults.Keys.Contains(t.ManagedThreadId))
                {
                    result = false;
                    errorId = t.ManagedThreadId;
                    break;
                }
            }

            Assert.IsTrue(result, $"Thread result should contain id = {errorId} ");
        }

        [TestMethod]
        public void TraceResult_NestedCalls()
        {
            int expected = 1;

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].Methods.Count;

            Assert.IsTrue(actual == expected, $"Thread result should contain {expected} nested call");
        }

        private void MultipleThreadMethod(ClassLibrary1lab_spp.Tracer tracer)
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(()=>TestMethod1(tracer));
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private void TestMethod1(ClassLibrary1lab_spp.Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(50);
            TestMethod2(tracer);
            tracer.StopTrace();
        }

        private void TestMethod2(ClassLibrary1lab_spp.Tracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}