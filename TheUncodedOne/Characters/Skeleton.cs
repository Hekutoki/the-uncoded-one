using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

class Skeleton : Character
{
	public Skeleton(string name = "SKELETON", bool isNPC = true) : base(name,
		new List<Attack>() { new BoneCrunch() },
		maxHealth: 5, 
		isPlayable: isNPC) { }
}
