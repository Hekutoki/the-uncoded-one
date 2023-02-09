using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items;

namespace TheUncodedOne.Actions;

class EquipGearAction : IAction
{
	public string Name => "Equip gear";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Party allyParty = battle.GetAllyParty(performingCharacter);
		Gear gear = performingCharacter.ChooseGear(allyParty);

		Gear? oldGear = performingCharacter.EquipGear(gear);

		allyParty.Inventory.RemoveItem(gear);
		if (oldGear != null) allyParty.Inventory.AddItem(oldGear);

		Console.WriteLine($"{performingCharacter} equipped {gear}");
	}

	public override string ToString() => Name;
}
