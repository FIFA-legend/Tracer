using System.Collections.Generic;
using System.Xml.Serialization;
using Tracer.entities;

namespace Tracer.Entities
{
    [XmlRoot("root")]
    public class TraceResult
    {
        [XmlElement(ElementName = "thread")]
        public List<Thread> Threads = new List<Thread>();
    }
}