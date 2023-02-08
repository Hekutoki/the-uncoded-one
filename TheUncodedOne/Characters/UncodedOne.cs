using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

class UncodedOne : Character
{
	public UncodedOne(string name = "UNCODED ONE", bool isNPC = true) : base(name,
		new List<Attack>() { new Unraveling() },
		maxHealth: 15,
		isPlayable: isNPC) { }
}
