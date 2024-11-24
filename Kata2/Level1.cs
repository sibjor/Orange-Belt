namespace Kata2;
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
 public string Name { get; set; }
 public int Health { get; private set; }
 
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
  Health -= damage;
  if (Health < 0) Health = 0;
  HealthChanged?.Invoke(this, damage);
 }
}