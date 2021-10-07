using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tracer.entities
{
    public class Method
    {
        [XmlAttribute("time")]
        public long Time;
        [XmlElement(ElementName = "method")]
        public List<Method> Methods;
        [XmlAttribute("name")]
        public string Name;
        [XmlAttribute("class")]
        public string ClassName;
    }
}