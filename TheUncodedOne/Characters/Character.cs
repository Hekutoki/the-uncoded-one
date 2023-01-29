using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

abstract class Character : IDamageable
{
    public abstract string Name { get; init; }
    public abstract List<IAction> Actions { get; init; }
    public abstract List<Attack> Attacks { get; init; }

    public Character(string name, List<IAction> actions, List<Attack> attacks)
    {
        Name = name;
        Actions = new();
        Attacks = new();

        foreach (IAction action in actions)
        {
            if (action == null)
            {
                throw new Exception(); // Should be null reference exception (?)
            }

            Actions.Add(action);
        }

		foreach (Attack attack in attacks)
		{
			Attacks.Add(attack);
		}
	}

    public abstract void PerformAction();

    public  abstract Attack ChooseAttack();

    public abstract void TakeDamage(int damageAmount);
}
