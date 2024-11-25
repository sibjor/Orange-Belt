namespace Kata3;

class Program
{
    static void Main(string[] args)
    {
        var abilityContainer = new AbilityContainer<IAbility>();
        
        var fireball = new AttackAbility("Fireball", "Deals 50 fire damage to a single target.");
        var healingWave = new HealAbility("Healing Wave", "Restores 30 health to all allies.");

        abilityContainer.AddAbility(fireball);
        abilityContainer.AddAbility(healingWave);

        abilityContainer.DisplayAbilities();
        
        abilityContainer.RemoveAbility(fireball);

        Console.WriteLine("\nAfter removing Fireball:");
        abilityContainer.DisplayAbilities();
    }
}