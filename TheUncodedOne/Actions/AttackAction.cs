using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

// This class handles taking info from player and then displaying it
// Probably should be changed
class AttackAction : IAction
{
	public string Name => "Attack";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Attack attack = performingCharacter.ChooseAttack();
		Character targetCharacter = performingCharacter.ChooseTarget(battle);
		Console.WriteLine($"{performingCharacter.Name} used {attack.Name} on {targetCharacter.Name}");
	}
}
