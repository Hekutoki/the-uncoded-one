namespace TheUncodedOne.Attacks;

internal class Stab : Attack
{
	public Stab() : base("STAB", true) { }

	public override int GetDamage() => 1;
}
