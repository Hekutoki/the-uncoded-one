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
			aiCharacter: false, 
			maxHealth: 25) { }

	public override void PerformAction(Battle battle)
	{
		// 1 is Attack action
		if (IsAICharacter) Actions[1].Perform(this, battle);
		else
		{
			User.DisplayActions(Actions);
			int userNumber = User.GetNumber("What do you do?", Actions.Count);

			Actions[userNumber].Perform(this, battle);
		}
	}

	public override Attack ChooseAttack()
	{
		if (IsAICharacter) return Attacks[new Random().Next(Attacks.Count)];

		User.DisplayAttacks(Attacks);
		int userNumber = User.GetNumber("What attack do you choose?", Attacks.Count);

		return Attacks[userNumber];
	}

	public override Character ChooseTarget(Battle battle)
	{
		Party enemyParty = battle.GetEnemyParty(this);
		int characterCount = enemyParty.Characters.Count;

		if (IsAICharacter)	return enemyParty.Characters[new Random().Next(characterCount)];

		User.DisplayTargets(enemyParty.Characters);
		int userNumber = User.GetNumber("Who is your target?", characterCount);

		return enemyParty.Characters[userNumber];
	}
}
