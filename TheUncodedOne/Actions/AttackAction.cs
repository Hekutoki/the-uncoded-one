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
		targetCharacter.Health += -damage;

		Console.WriteLine($"{performingCharacter} used {attack} on {targetCharacter}.");
		Console.WriteLine($"{attack} dealt {damage} to {targetCharacter}");
		Console.WriteLine($"{targetCharacter} is now at {targetCharacter.Health}/{targetCharacter.MaxHealth}");

		if (targetCharacter.Health <= 0)
		{
			Party allyParty = battle.GetAllyParty(targetCharacter);
			string gearTransfer = "";

			if (targetCharacter.EquippedGear != null)
			{
				allyParty.Inventory.Gear.Add(targetCharacter.EquippedGear);
				gearTransfer = $"{targetCharacter}'s gear has been returned to party inventory.";
			}

			allyParty.RemovePartyMember(targetCharacter);

			Console.WriteLine($"{targetCharacter} has been defeated! {gearTransfer}");
		}
	}

	public override string ToString() => Name;
}
