using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items;

namespace TheUncodedOne.Actions;

class UseItemAction : IAction
{
	public string Name => "Use item";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Party allyParty = battle.GetAllyParty(performingCharacter);
		Item item;
		Character targetCharacter;

		if (performingCharacter.IsPlayable)
		{
			item = performingCharacter.ChooseItem(allyParty);
			targetCharacter = performingCharacter.ChooseTarget(battle, false);
		}
		else
		{
			targetCharacter = performingCharacter;

			if (performingCharacter.Intent == Intent.Heal)
				item = allyParty.Inventory.Items.Where(i => i is HealingPotion).First();
			else
				item = allyParty.Inventory.Items[0];
		}

		item.Use(targetCharacter);
		allyParty.Inventory.RemoveItem(item);

		Console.WriteLine($"{battle.GetAllyParty(performingCharacter)} used {item} on {targetCharacter}");
	}
}
