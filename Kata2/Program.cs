namespace Kata2;

class Program
{
    public static void Main(string[] args)
    {
        Character hero = new Character("Hero", 100);
        Character villain = new Character("Villain", 80);
        
        hero.HealthChanged += (character, damage) =>
        {
            Console.WriteLine($"{character.Name} took {damage} damage! Remaining health: {character.Health}");
        };

        villain.HealthChanged += (character, damage) =>
        {
            Console.WriteLine($"{character.Name} took {damage} damage! Remaining health: {character.Health}");
        };
        
        Console.WriteLine("\nBattle starts!");
        hero.Attack(villain, 30); 
        villain.Attack(hero, 25); 
        
        hero.Attack(villain, 20); 
        villain.Attack(hero, 15);

        Console.WriteLine("\nBattle ends!");
    }
}