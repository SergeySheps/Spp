namespace ClassLibrary1lab_spp
{
    interface ITracer
    {
        void StartTrace();
        void StopTrace();
        TraceResult GetTraceResult();
    }
}
