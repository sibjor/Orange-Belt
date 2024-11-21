using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata1
{
    public class Level1
    {
        private List<Character> _warriors = new();
        private Character _healer;
        private Random _random = new();

        public Level1(int warriorsCount)
        {
            InitWarriors(warriorsCount);
            InitHealer();

            while (_warriors.Count > 1)
            {
                _warriors.RemoveAll(w => w.Health <= 0);
                
                var warriorsToAttack = _warriors.OrderBy(w => w.Health < 50 ? 0 : 1).ThenBy(w => w.Health).ToList();
                
                var attacker = warriorsToAttack.First();
                
                var validTargets = _warriors.Where(w => w != attacker).ToList();
                if (validTargets.Count > 0)
                {
                    var target = validTargets[_random.Next(validTargets.Count)];
                    attacker.PrimaryAction(attacker, target);
                    Console.WriteLine($"{attacker.Name} attacks {target.Name} for {attacker.Damage} damage. {target.Name}'s health is now {target.Health}");
                }
                
                var lowestHealthWarrior = _warriors.OrderBy(w => w.Health).First();
                _healer.PrimaryAction(_healer, lowestHealthWarrior);
                Console.WriteLine($"{_healer.Name} heals {lowestHealthWarrior.Name} for {_healer.Mana}. {lowestHealthWarrior.Name}'s health is now {lowestHealthWarrior.Health}");
            }
            
            if (_warriors.Count == 1)
            {
                Console.WriteLine($"The battle is over! {_warriors[0].Name} is the last warrior standing with {_warriors[0].Health} health.");
            }
        }

        private void InitWarriors(int warriorsCount)
        {
            for (int i = 0; i < warriorsCount; i++)
            {
                _warriors.Add(new Character(
                    $"Warrior {i + 1}",
                    55, 
                    25,
                    0, 
                    (self, target) => target.Health -= self.Damage
                ));
            }
        }

        private void InitHealer()
        {
            _healer = new Character(
                "Healer",
                55,
                0,
                15,
                (self, target) => target.Health += self.Mana 
            );
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Mana { get; set; }
        public Action<Character, Character> PrimaryAction { get; set; }

        public Character(string name, int health, int damage, int mana, Action<Character, Character> primaryAction)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Mana = mana;
            PrimaryAction = primaryAction;
        }
    }
    
}
