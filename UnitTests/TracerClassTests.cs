using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab1.Entities;
using lab1.Serialization;
using Tracer;
using Tracer.entities;
using Tracer.Entities;
using Thread = System.Threading.Thread;

namespace UnitTests
{
    [TestClass]
    public class TracerClassTests
    {
        TraceResult _traceResult;

        [TestInitialize]
        public void Setup()
        {
            TracerClass tracer = new TracerClass();

            Foo foo = new Foo(tracer);
            Bar bar = new Bar(tracer);
            AnotherClass anotherObject = new AnotherClass(tracer);

            tracer.StartTrace();
            anotherObject.AnotherMethod();
            foo.MyMethod();
            bar.InnerMethod();
            tracer.StopTrace();

            Thread secondThread = new Thread(foo.MyMethod);
            secondThread.Start();
            secondThread.Join();

            _traceResult = tracer.GetTraceResult();
            ISerializer serializer = new MyXmlSerializer();
            Console.WriteLine(serializer.Serialize(_traceResult));
        }

        [TestMethod]
        public void Test_Thread_Count()
        {
            Assert.AreEqual(2, _traceResult.Threads.Count);
        }

        [TestMethod]
        public void Test_FirstLevelMethods_Count()
        {
            Assert.AreEqual(3, _traceResult.Threads[0].Methods[0].Methods.Count);
        }

        [TestMethod]
        public void Test_InnerMethod()
        {
            Method innerMethod = _traceResult.Threads[0].Methods[0].Methods[0].Methods[1];
            Assert.AreEqual("InnerMethod", innerMethod.Name, "Wrong method name");
            Assert.AreEqual("Bar", innerMethod.ClassName, "Wrong class name");
        }
        
        [TestMethod]
        public void Test_SecondThread()
        {
            Method outerMethod = _traceResult.Threads[1].Methods[0];
            Method innerMethod = _traceResult.Threads[1].Methods[0].Methods[0];
            
            Assert.AreEqual("MyMethod", outerMethod.Name, "Wrong outer method name");
            Assert.AreEqual("Foo", outerMethod.ClassName, "Wrong outer class name");
            
            Assert.AreEqual("InnerMethod", innerMethod.Name, "Wrong inner method name");
            Assert.AreEqual("Bar", innerMethod.ClassName, "Wrong inner class name");
        }
    }
}
