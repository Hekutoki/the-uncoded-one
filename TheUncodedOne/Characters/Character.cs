using System.ComponentModel.Design;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

abstract class Character
{
    public string Name { get; }
    public int MaxHealth { get; }
    public int Health { get; protected set; }
    public bool IsAICharacter { get; }
    public List<IAction> Actions { get; }
    public List<Attack> Attacks { get; }

    public Character(string name, List<IAction> actions, List<Attack> attacks, int maxHealth, bool aiCharacter = true)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = MaxHealth;
        IsAICharacter = aiCharacter;

        Actions = actions.Where(a => a != null).ToList();
        Attacks = attacks;
	}

    // This should be the only method, that outside world needs to call,
    // for character to perform (choose action, choose attack/potion, choose target etc.) an action
    public abstract void PerformAction(Battle battle);

    public abstract Attack ChooseAttack();

    // This method maybe better suited to be implemented here
    // and made virtual later, if something changes. 
    // (Look at Player's and Skeleton's class implementation)
    public abstract Character ChooseTarget(Battle battle);

    // Method called when something from the outside
    // is trying to damage this character
    public virtual void TakeDamage(int damageAmount) 
    {
        if (Health > 0) Health -= damageAmount;

        if (Health < 0) Health = 0;
    }
}
