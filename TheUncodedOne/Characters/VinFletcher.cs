using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne.Characters;

class VinFletcher : Character
{
	public VinFletcher(bool isPlayable = false, Gear? gear = null) : base("VIN FLETCHER",
		new List<Attack> { new Punch() },
		maxHealth: 15,
		isPlayable,
		gear: gear) { }
}
