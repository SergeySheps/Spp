using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary1lab_spp
{

    public class MethodInfo
    {
        private readonly Stopwatch stopwatch;
        public string methodName;
        public string className;
        public long time;
        public List<MethodInfo> Methods { get; }

        public MethodInfo(){
        }

        public MethodInfo(MethodBase methodBase)
        {
            stopwatch = new Stopwatch();
            Methods = new List<MethodInfo>();
            methodName = methodBase.Name;
            className = methodBase.DeclaringType?.Name;
        }

        public void AddMethod(MethodInfo method)
        {
            Methods.Add(method);
        }

        public void StartMethodTrace()
        {
            stopwatch.Start();
        }

        public void StopMethodTrace()
        {
            stopwatch.Stop();
            time = stopwatch.ElapsedMilliseconds;
        }
    }
}
