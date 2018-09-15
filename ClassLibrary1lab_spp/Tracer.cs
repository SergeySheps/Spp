using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ClassLibrary1lab_spp
{
    public class Tracer : ITracer
    {
        public void StartTrace ()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            //Thread.Sleep(1000);
            var methodInfo = new MethodInfo(method);
            methodInfo.StartMethodTrace();
            Thread.Sleep(1000);
            methodInfo.StopMethodTrace();
            Console.WriteLine(methodInfo.Class+" Class");
            Console.WriteLine(methodInfo.Name + " Name");
            Console.WriteLine(methodInfo.Time + " Time");
            //TraceResult.StartMethodTrace(method);
        }

        public void StopTrace()
        {

        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult();
        }
    }
}
