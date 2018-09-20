using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1lab_spp;

namespace Tracer.Tests
{
    [TestClass]
    public class TracerTest
    {
        private TraceResult traceResult;

        [TestInitialize]
        public void Init()
        {
            var tracer = new ClassLibrary1lab_spp.Tracer();

            TestMethod1(tracer);
            traceResult = tracer.TraceResult;
        }

        [TestMethod]
        public void TraceResult_TimeMoreOrEqual100()
        {
            long expected = 100;

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Time;
            Assert.IsTrue(expected <= actual, $"Time should be equal ${expected}ms");
        }

        [TestMethod]
        public void TraceResult_TimeLessOrEqual200()
        {
            long expected = 200;

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Time;

            Assert.IsTrue(expected >= actual, $"Time should be equal ${expected}ms");
        }

        [TestMethod]
        public void TraceResult_MethodName()
        {
            string expected = nameof(TestMethod1);

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].Name;

            Assert.IsTrue(expected == actual, $"Method name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ClassName()
        {
            string expected = "TracerTest";

            var actual = traceResult.ThreadResults.Values.FirstOrDefault()?.Methods[0].Class;

            Assert.IsTrue(expected == actual, $"Class name should be {expected}");
        }

        [TestMethod]
        public void TraceResult_ThreadId()
        {
            int expected = Thread.CurrentThread.ManagedThreadId;

            var actual = traceResult.ThreadResults.Keys.Contains(expected);

            Assert.IsTrue(actual, $"Thread result should contain {expected} id");
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