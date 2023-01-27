using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

class Skeleton : Character
{
	public override string Name { get; init; }
	public override List<IAction> Actions { get; init; }

	public Skeleton() : base("SKELETON", new List<IAction>() { new DoNothingAction() }) { }

	public override void PerformAction()
	{
		Actions[0].PerformAction(this);
	}

	public override void TakeDamage(int damageAmount)
	{
		throw new NotImplementedException();
	}
}
