using TheUncodedOne.Characters;

namespace TheUncodedOne.Items.Consumables;

abstract class Consumable
{
	public string Name { get; }

	public Consumable(string name) { Name = name; }

	public abstract void Use(Character targetCharacter);

	public override string ToString()
	{
		return Name;
	}
}
