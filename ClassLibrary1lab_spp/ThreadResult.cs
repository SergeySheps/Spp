using System.Collections.Generic;
using System.Reflection;

namespace ClassLibrary1lab_spp
{
    public class ThreadResult
    {
        public List<MethodInfo> Methods { get; }
        private readonly Stack<MethodInfo> stack;

        public ThreadResult()
        {
            Methods = new List<MethodInfo>();
            stack = new Stack<MethodInfo>();
        }

        public void StartMethodTrace(MethodBase methodBase)
        {
            var method = new MethodInfo(methodBase);
            if (stack.Count == 0)
            {
                Methods.Add(method);
            }
            else
            {
                stack.Peek().AddMethod(method);
            }
            stack.Push(method);
            method.StartMethodTrace();
        }

        public void StopMethodTrace()
        {
            stack.Pop().StopMethodTrace();
        }
    }
}
