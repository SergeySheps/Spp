using System.Diagnostics;
using System.Reflection;


namespace ClassLibrary1lab_spp
{
    public class Tracer : ITracer
    {
        private TraceResult TraceResult;

        public Tracer()
        {
            TraceResult = new TraceResult();
        }

        public void StartTrace ()
        {
            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();
            var traceResult = GetTraceResult();
            traceResult.StartMethodTrace(method);
        }

        public void StopTrace()
        {
            TraceResult.StopMethodTrace();
        }

        public TraceResult GetTraceResult()
        {      
            return TraceResult;
        }
    }
}
