using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace ClassLibrary1lab_spp
{
    [Serializable]
    public class ThreadResult
    {
        public int id = Thread.CurrentThread.ManagedThreadId;
        public long time ;
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
            time = Methods[0].time;
        }
    }
}
