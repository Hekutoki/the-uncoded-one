namespace TheUncodedOne.Attacks;

class Punch : Attack
{
	public Punch() : base("PUNCH") { }

	public override int GetDamage() => 1;
}
