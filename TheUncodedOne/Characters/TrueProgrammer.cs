using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne.Characters;

class TrueProgrammer : Character
{
	public TrueProgrammer(bool isNPC = false, Gear? gear = null) : base(User.GetString("What's your name, Programmer?"),
		new List<Attack>() { new Punch() },
		isPlayable: isNPC, 
		maxHealth: 25,
		gear: gear) { }
}
