using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

class Skeleton : Character
{
	public Skeleton() : base("SKELETON", 
		new List<IAction>() { new DoNothingAction(), new AttackAction() },
		new List<Attack>() { new Attack("BONE CRUNCH") }) { }

	public override void PerformAction()
	{
		Actions[new Random().Next(Actions.Count)].Perform(this);
	}

	public override void TakeDamage(int damageAmount)
	{
		throw new NotImplementedException();
	}

	public override Attack ChooseAttack()
	{
		return Attacks[new Random().Next(Attacks.Count)];
	}
}
