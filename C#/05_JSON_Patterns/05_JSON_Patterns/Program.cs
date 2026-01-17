namespace _05_JSON_Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonLesson json = new JsonLesson();

            JsonItem? item = json.ToObject();
            var collection = json.ToCollection();   

            string json1 = json.ToJson(item!);
            string json2 = json.ToJson(collection);
        }
    }
}
