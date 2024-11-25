namespace Kata3;

public class Level1
{
    
}

public interface IAbility // I defined the base first, generic class can be found below!
{
    string Name { get; }
    string Effect { get; }
}
public class AttackAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public AttackAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}

public class HealAbility : IAbility
{
    public string Name { get; private set; }
    public string Effect { get; private set; }

    public HealAbility(string name, string effect)
    {
        Name = name;
        Effect = effect;
    }
}
public class AbilityContainer<T> where T : IAbility 
{
    private readonly List<T> abilities = new List<T>();
    
    public void AddAbility(T ability)
    {
        if (ability == null)
        {
            throw new ArgumentNullException(nameof(ability), "Ability cannot be null.");
        }
        abilities.Add(ability);
    }
    
    public bool RemoveAbility(T ability)
    {
        return abilities.Remove(ability);
    }
    
    public IEnumerable<T> GetAbilities()
    {
        return new List<T>(abilities);
    }
    public void DisplayAbilities()
    {
        if (abilities.Count == 0)
        {
            Console.WriteLine("No abilities in the container.");
            return;
        }

        Console.WriteLine("Abilities in the container:");
        foreach (var ability in abilities)
        {
            Console.WriteLine($"- {ability.Name}: {ability.Effect}");
        }
    }
}