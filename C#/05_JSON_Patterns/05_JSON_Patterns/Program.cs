namespace _05_JSON_Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //JsonLesson json = new JsonLesson();

            //JsonItem? item = json.ToObject();
            //var collection = json.ToCollection();   

            //string json1 = json.ToJson(item!);
            //string json2 = json.ToJson(collection);


            //Singleton singleton = Singleton.GetInstance();

            //TestSingleton();

            List<Zombie> zombies = new List<Zombie>();

            zombies.Add(new ZombieGreen(1.5f));
            zombies.Add(new ZombieRed(2.0f));
            zombies.Add(new ZombieYellow(2.0f));

        }

        static void TestSingleton()
        {
            Singleton singleton = Singleton.GetInstance();
        }
    }
}
