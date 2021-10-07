using System.Threading;
using Tracer;

namespace lab1.Entities
{
    public class AnotherClass
    {
        private readonly ITracer _tracer;
        private readonly Bar _bar;
        private int _count = 3;

        public AnotherClass(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void AnotherMethod()
        {
            _tracer.StartTrace();
            while (_count != 0)
            {
                _count--;
                AnotherMethod();
                _bar.InnerMethod();
            }
            Thread.Sleep(50);
            _tracer.StopTrace();
        }
    }
}