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
		Console.WriteLine(item.Name);
	}
}
