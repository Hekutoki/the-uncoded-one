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

	public override void PerformAction(Battle battle)
	{
		// 1 is Attack action
		Actions[1].Perform(this, battle);
	}

	public override Attack ChooseAttack()
	{
		return Attacks[new Random().Next(Attacks.Count)];
	}

	public override Character ChooseTarget(Battle battle)
	{
		Party enemyParty = battle.GetEnemyParty(this);
		int characterCount = enemyParty.Characters.Count;

		return enemyParty.Characters[new Random().Next(characterCount)];
	}
}
