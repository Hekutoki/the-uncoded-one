namespace TheUncodedOne.Attacks;

abstract class Attack
{
	public string Name { get; }
	public bool IsSpecial { get; }
	public float SuccessChance { get; }

	public bool IsSuccessful => _random.NextDouble() < SuccessChance ? true : false;

	private Random _random = new();

	public Attack(string name, bool isSpecial = false, float successChance = 1f)
	{
		Name = name;
		IsSpecial = isSpecial;
		SuccessChance = successChance;
	}

	public abstract int GetDamage();

	public override string ToString()
	{
		return Name;
	}
}
