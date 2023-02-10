using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items.Consumables;

namespace TheUncodedOne.Actions;

class UseConsumableAction : IAction
{
	public string Name => "Use consumable";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Party allyParty = battle.GetAllyParty(performingCharacter);
		Consumable consumable;
		Character targetCharacter;

		if (performingCharacter.IsPlayable)
		{
			consumable = performingCharacter.ChooseItem(allyParty);
			targetCharacter = performingCharacter.ChooseTarget(battle, false);
		}
		else
		{
			targetCharacter = performingCharacter;

			if (performingCharacter.Intent == Intent.Heal)
				consumable = allyParty.Inventory.Consumables.Where(i => i is HealingPotion).First();
			else
				consumable = allyParty.Inventory.Consumables[0];
		}

		consumable.Use(targetCharacter);
		allyParty.Inventory.Consumables.Remove(consumable);

		Console.WriteLine($"{battle.GetAllyParty(performingCharacter)} used {consumable} on {targetCharacter}");
	}

	public override string ToString() => Name;
}
