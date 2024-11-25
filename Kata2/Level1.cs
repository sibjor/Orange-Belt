namespace Kata2
{
    /*
     * Introduce basic C# features,
     * specifically delegates and events,
     * without applying SOLID principles.
     */
    public class Level1
    {
        
    }

    public class Character
    {
        public string Name { get; } // Read-only property
        public int Health { get; private set; } // Health can only be modified within this class

        public delegate void CharacterAction(Character target, int damage);
        public event CharacterAction HealthChanged;

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void Attack(Character target, int damage)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }

        private void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage); // Ensure Health never goes below zero
            HealthChanged?.Invoke(this, damage);
        }
    }
}