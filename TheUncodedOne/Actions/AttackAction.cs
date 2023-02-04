using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

class AttackAction : IAction
{
	public string Name => "Attack";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Attack attack = performingCharacter.ChooseAttack();
		int damage = attack.GetDamage();

		Character targetCharacter = performingCharacter.ChooseTarget(battle);
		targetCharacter.TakeDamage(damage);

		Console.WriteLine($"{performingCharacter} used {attack.Name} on {targetCharacter}.");
		Console.WriteLine($"{attack.Name} dealt {damage} to {targetCharacter}");
		Console.WriteLine($"{targetCharacter} is now at {targetCharacter.Health}/{targetCharacter.MaxHealth}");

		if (targetCharacter.Health <= 0)
		{
			battle.GetAllyParty(targetCharacter).RemovePartyMember(targetCharacter);

			Console.WriteLine($"{targetCharacter} has been defeated!");
		}
	}
}
