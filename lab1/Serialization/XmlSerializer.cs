using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace lab1.Serialization
{
    public class MyXmlSerializer : ISerializer
    {
        private readonly XmlSerializerNamespaces _emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        public string Serialize(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using TextWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, obj, _emptyNamespaces);
            return textWriter.ToString();
        }
    }
}