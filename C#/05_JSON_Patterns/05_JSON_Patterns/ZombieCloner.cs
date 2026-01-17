namespace _05_JSON_Patterns
{
    public class ZombieCloner
    {
        private List<Zombie> zombies;

        public ZombieCloner()
        {
            zombies = new List<Zombie>();
        }

        public void CloneZombies(Zombie zombie, int count)
        {
            for (int i = 0; i < count; i++)
            {;
                zombies.Add(zombie.Clone());
            }
        }
    }
}
