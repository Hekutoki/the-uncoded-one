using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

class Skeleton : Character
{
	public Skeleton(string name = "SKELETON", bool isNPC = true) : base(name,
		new List<IAction>() { new DoNothingAction(), new AttackAction() },
		new List<Attack>() { new BoneCrunch() },
		maxHealth: 1, 
		isPlayable: isNPC) { }
}
