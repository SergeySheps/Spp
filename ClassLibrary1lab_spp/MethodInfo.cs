using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary1lab_spp
{
    public class MethodInfo
    {
        private readonly Stopwatch stopwatch;
        public string Name { get; }
        public string Class { get; }
        public long Time => stopwatch.ElapsedMilliseconds;
        public List<MethodInfo> Methods { get; }

        public MethodInfo(MethodBase methodBase)
        {
            stopwatch = new Stopwatch();
            Methods = new List<MethodInfo>();
            Name = methodBase.Name;
            Class = methodBase.DeclaringType?.Name;
        }

        public void AddMethod(MethodInfo method)
        {
            Methods.Add(method);
        }

        public void StartMethodTrace()
        {
            stopwatch.Start();
        }

        //public static long GetMethodTraceTime()
        //{
        //    return stopwatch.ElapsedMilliseconds;
        //}

        public void StopMethodTrace()
        {
            stopwatch.Stop();
        }
    }
}
