using TheUncodedOne.Actions;
namespace TheUncodedOne;

class Character : IDamageable
{
	public string Name { get; init; }
	public readonly List<IAction> Actions = new();

	public Character (string name) { Name = name; }

	public Character(string name, IAction action) : this(name) { Actions.Add(action); }

	public Character(string name, List<IAction> actions) : this(name) 
	{ 
		foreach(IAction action in actions) 
		{ 
			if (action == null)
			{
				throw new Exception(); // Should be null reference exception (?)
			}

			Actions.Add(action); 
		}
	}

	public void TakeDamage(int damageAmount)
	{
		throw new NotImplementedException();
	}
}
