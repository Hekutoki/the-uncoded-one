namespace TheUncodedOne.Attacks;

abstract class Attack
{
	public string Name { get; }
	public bool IsSpecial { get; }

	public Attack(string name, bool isSpecial = false)
	{
		Name = name;
		IsSpecial = isSpecial;
	}

	public abstract int GetDamage();

	public override string ToString()
	{
		return Name;
	}
}
