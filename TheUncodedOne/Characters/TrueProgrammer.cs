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
	public TrueProgrammer() : base(User.GetString("What's your name, Programmer?"),
		new List<IAction>() { new DoNothingAction(), new AttackAction() },
		new List<Attack>() { new Punch() },
		isNPC: false, 
		maxHealth: 25) { }
}
