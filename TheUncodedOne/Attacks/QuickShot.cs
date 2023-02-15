namespace TheUncodedOne.Attacks;

class QuickShot : Attack
{
	public QuickShot() : base("Quick shot", true, 0.5f) { }

	public override int GetDamage() => 3;
}
