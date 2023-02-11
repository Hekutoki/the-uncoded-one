namespace TheUncodedOne.Attacks
{
	internal class Unraveling : Attack
	{
		private Random random = new();

		public Unraveling() : base("UNRAVELING ATTACK") { }

		public override int GetDamage() => random.Next(2);
	}
}
