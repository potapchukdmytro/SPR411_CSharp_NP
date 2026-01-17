namespace _05_JSON_Patterns
{
    public class Zombie : IPrototype<Zombie>
    {
        private readonly float healthFactor;

        public float Speed { get; set; }

        public float Damage { get; set; }
        public float Health { get; set; }

        public Zombie(float healthFactor)
        {
            this.healthFactor = healthFactor;
        }

        public Zombie Clone()
        {
            var clone = new Zombie(healthFactor)
            {
                Speed = Speed,
                Damage = Damage,
                Health = Health
            };

            return clone;
        }
    }
}
