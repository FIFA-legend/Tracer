using Newtonsoft.Json;

namespace lab1.Serialization
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSettings);
        }
    }
}