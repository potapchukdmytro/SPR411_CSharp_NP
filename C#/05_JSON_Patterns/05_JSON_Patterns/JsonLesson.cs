using System.Text.Json;

namespace _05_JSON_Patterns
{
    public class JsonLesson
    {
        private const string itemPath = "item.json";
        private const string collectionPath = "collection.json";

        private string itemJson;
        private string collectionJson;

        public JsonLesson()
        {
            itemJson = File.ReadAllText(itemPath);
            collectionJson = File.ReadAllText(collectionPath);
        }

        public JsonItem? ToObject()
        {
            // Deserialize - json to object
            JsonItem? item = JsonSerializer.Deserialize<JsonItem>(itemJson);
            return item;
        }

        public List<JsonItem> ToCollection()
        {
            List<JsonItem>? collection = JsonSerializer.Deserialize<List<JsonItem>>(collectionJson);
            return collection ?? new List<JsonItem>();
        }

        public string ToJson(JsonItem item)
        {
            // Serialize - object to json
            string json = JsonSerializer.Serialize(item);
            return json;
        }

        public string ToJson(List<JsonItem> collection)
        {
            string json = JsonSerializer.Serialize(collection);
            return json;
        }
    }
}
