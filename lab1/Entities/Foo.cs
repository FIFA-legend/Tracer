using System.Threading;
using Tracer;

namespace lab1.Entities
{
    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }
        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _bar.InnerMethod();
            _tracer.StopTrace();
        }
    }
}