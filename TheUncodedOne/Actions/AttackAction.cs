using TheUncodedOne.Attacks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

// Wolololo test-issue
class AttackAction : IAction
{
	public string Name => "Attack";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Attack attack = performingCharacter.ChooseAttack();
		int damage = attack.GetDamage();

		Character targetCharacter = performingCharacter.ChooseTarget(battle);

		if (targetCharacter.Modifier.HasValue) damage += targetCharacter.Modifier.Value.DamageChange;

		if (!attack.IsSuccessful) Console.WriteLine($"{performingCharacter} missed!");
		else
		{
			targetCharacter.Health += -damage;

			DisplayAttackInfo(performingCharacter, targetCharacter, attack, damage);

			if (targetCharacter.Health <= 0)
			{
				KillCharacter(battle, targetCharacter);
			}
		}
	}

	public override string ToString() => Name;

	private void DisplayAttackInfo(Character performingCharacter, Character targetCharacter, Attack attack, int damage)
	{
		Console.WriteLine($"{performingCharacter} used {attack} on {targetCharacter}.");

		if (targetCharacter.Modifier.HasValue) Console.WriteLine($"{targetCharacter.Modifier.Value.Message}");

		Console.WriteLine($"{attack} dealt {damage} to {targetCharacter}");
		Console.WriteLine($"{targetCharacter} is now at {targetCharacter.Health}/{targetCharacter.MaxHealth}");
	}

	private void KillCharacter(Battle battle, Character targetCharacter)
	{
		string gearTransfer = "";

		if (targetCharacter.EquippedGear != null)
		{
			battle.GetEnemyParty(targetCharacter).Inventory.Gear.Add(targetCharacter.EquippedGear);

			gearTransfer = $"{targetCharacter}'s {targetCharacter.EquippedGear} has been stolen by {battle.GetEnemyParty(targetCharacter)}.";
		}

		battle.GetAllyParty(targetCharacter).RemovePartyMember(targetCharacter);

		Console.WriteLine($"{targetCharacter} has been defeated! {gearTransfer}");
	}
}
