namespace _05_JSON_Patterns
{
    public class Singleton
    {
        private static Singleton? instance = null;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }
}
