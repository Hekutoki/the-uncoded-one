using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne.Characters;

class Skeleton : Character
{
	public Skeleton(string name = "SKELETON", bool isNPC = true, Gear? gear = null) : base(name,
		new List<Attack>() { new BoneCrunch() },
		maxHealth: 5, 
		isPlayable: isNPC,
		gear: gear) { }
}
