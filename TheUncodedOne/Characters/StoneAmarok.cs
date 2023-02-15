using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne.Characters;

class StoneAmarok : Character
{
	public StoneAmarok(bool isPlayable = true, Gear? gear = null) : base("STONE AMAROK",
		new List<Attack>() { new Bite() },
		maxHealth: 4,
		isPlayable: isPlayable,
		gear: gear,
		new AttackModifier(-1, "STONE ARMOR")) { }
}
