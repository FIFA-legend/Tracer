using System;
using lab1.Entities;
using Tracer;
using lab1.Serialization;
using lab1.Writing;
using Tracer.Entities;
using Thread = System.Threading.Thread;

namespace lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            TracerClass tracer = new TracerClass();

            Foo foo = new Foo(tracer);
            Bar bar = new Bar(tracer);
            AnotherClass anotherObject = new AnotherClass(tracer);

            tracer.StartTrace();
            anotherObject.AnotherMethod();
            bar.InnerMethod();
            tracer.StopTrace();

            Thread secondThread = new Thread(foo.MyMethod);
            secondThread.Start();

            Thread thirdThread = new Thread(bar.InnerMethod);
            thirdThread.Start();

            secondThread.Join();
            thirdThread.Join();

            TraceResult traceResult = tracer.GetTraceResult();

            ISerializer serializerJson = new JsonSerializer();
            ISerializer serializerXml = new MyXmlSerializer();
            IWriter consoleWriter = new ConsoleWriter();
            IWriter jsonFileWriter = new FileWriter(Environment.CurrentDirectory + "\\" + "Json" + "." + "txt");
            IWriter xmlFileWriter = new FileWriter(Environment.CurrentDirectory + "\\" + "Xml" + "." + "txt");

            string json = serializerJson.Serialize(traceResult);
            string xml = serializerXml.Serialize(traceResult);

            consoleWriter.Write(json);
            consoleWriter.Write(xml);

            jsonFileWriter.Write(json);
            xmlFileWriter.Write(xml);
        }
    }
}