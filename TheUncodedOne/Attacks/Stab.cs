namespace TheUncodedOne.Attacks;

internal class Stab : Attack
{
	public Stab() : base("STAB") { }

	public override int GetDamage() => 1;
}
