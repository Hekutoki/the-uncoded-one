using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

class TrueProgrammer : Character
{
    public TrueProgrammer() : base(User.GetString("What's your name, Programmer?"),
            new List<IAction>() { new DoNothingAction(), new AttackAction() },
            new List<Attack>() { new Attack("PUNCH") })
    { }

	public override void PerformAction(Battle battle)
	{
		// 1 is Attack action
		Actions[1].Perform(this, battle);
	}

	public override void TakeDamage(int damageAmount)
	{
		throw new NotImplementedException();
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
