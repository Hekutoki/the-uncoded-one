using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

abstract class Character : IDamageable
{
    public abstract string Name { get; init; }
    public abstract List<IAction> Actions { get; init; }

    public Character(string name, List<IAction> actions)
    {
        Name = name;
        Actions = new();

        foreach (IAction action in actions)
        {
            if (action == null)
            {
                throw new Exception(); // Should be null reference exception (?)
            }

            Actions.Add(action);
        }
    }

    public abstract void PerformAction();

    public abstract void TakeDamage(int damageAmount);
}
