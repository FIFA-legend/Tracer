using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tracer.entities
{
    public class Thread
    {
        [XmlAttribute("id")]
        public int Id;
        [XmlAttribute("time")]
        public long Time;
        [XmlElement(ElementName = "method")]
        public List<Method> Methods;
    }
}