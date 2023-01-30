using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

abstract class Character : IDamageable
{
    public string Name { get; }
    public List<IAction> Actions { get; init; }
    public List<Attack> Attacks { get; init; }

    public Character(string name, List<IAction> actions, List<Attack> attacks)
    {
        Name = name;
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
    public abstract void TakeDamage(int damageAmount);
}
