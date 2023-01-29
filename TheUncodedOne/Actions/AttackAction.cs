using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

class AttackAction : IAction
{
	public string Name => "Attack";

	public void PerformAction(Character performingCharacter)
	{
		Attack attack = performingCharacter.ChooseAttack();
		Console.WriteLine($"{performingCharacter.Name} used {attack.Name}");
	}
}
