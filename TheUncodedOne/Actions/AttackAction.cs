using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;
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
		int damage = attack.GetDamage();

		Character targetCharacter = performingCharacter.ChooseTarget(battle);
		targetCharacter.TakeDamage(damage);

		Console.WriteLine($"{performingCharacter.Name} used {attack.Name} on {targetCharacter.Name}.");
		Console.WriteLine($"{attack.Name} dealt {damage} to {targetCharacter.Name}");
		Console.WriteLine($"{targetCharacter.Name} is now at {targetCharacter.Health}/{targetCharacter.MaxHealth}");

		if (targetCharacter.Health <= 0)
		{
			battle.GetAllyParty(targetCharacter).RemovePartyMember(targetCharacter);
			Console.WriteLine($"{targetCharacter.Name} has been defeated!");
		}
	}
}
