using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne.Characters;

class UncodedOne : Character
{
	public UncodedOne(string name = "UNCODED ONE", bool isNPC = true, Gear? gear = null) : base(name,
		new List<Attack>() { new Unraveling() },
		maxHealth: 15,
		isPlayable: isNPC,
		gear: gear) { }
}
