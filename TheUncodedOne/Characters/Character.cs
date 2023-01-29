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

    public abstract void PerformAction();

    public  abstract Attack ChooseAttack();

    public abstract void TakeDamage(int damageAmount);
}
