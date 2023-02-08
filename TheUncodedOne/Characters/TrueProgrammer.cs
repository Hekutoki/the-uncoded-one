using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

class TrueProgrammer : Character
{
	public TrueProgrammer(bool isNPC = false) : base(User.GetString("What's your name, Programmer?"),
		new List<Attack>() { new Punch() },
		isPlayable: isNPC, 
		maxHealth: 25) 
	{
		Health = 3;
	}
}
