using TheUncodedOne.Attacks;

namespace TheUncodedOne.Items.Gear;

class Gear
{
	public string Name { get; }
	public Attack Attack { get; }

	public Gear(string name, Attack attack)
	{
		Name = name;
		Attack = attack;
	}

	public override string ToString() => Name;
}
