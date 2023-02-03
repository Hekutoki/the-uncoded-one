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
	public UncodedOne(string name = "UNCODED ONE") : base(name,
		new List<IAction>() { new DoNothingAction(), new AttackAction() },
		new List<Attack>() { new Unraveling() },
		maxHealth: 2) { }
}
