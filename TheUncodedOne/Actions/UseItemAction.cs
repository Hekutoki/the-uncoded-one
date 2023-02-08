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
		Item item = performingCharacter.ChooseItem(battle.GetAllyParty(performingCharacter));

		Character targetCharacter = performingCharacter.ChooseTarget(battle, false);

		item.Use(targetCharacter);
		Console.WriteLine($"{battle.GetAllyParty(performingCharacter)} used {item} on {targetCharacter}");
	}
}
