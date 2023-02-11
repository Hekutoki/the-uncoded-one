namespace TheUncodedOne.Attacks;

class Slash : Attack
{
	public Slash() : base("SLASH", true) { }

	public override int GetDamage() => 2;
}
