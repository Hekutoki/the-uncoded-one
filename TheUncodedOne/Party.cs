using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items;

namespace TheUncodedOne;

class Party
{
	public string Name { get; }
	public Inventory Inventory { get; }

	private List<Character> _characters = new();
	public ReadOnlyCollection<Character> Characters => _characters.AsReadOnly();

	public Party (string partyName, List<Character> characters, Inventory inventory)
	{
		Name = partyName;
		foreach(Character character in characters) { _characters.Add(character); }
		Inventory = inventory;
	}

	public bool RemovePartyMember(Character character) => _characters.Remove(character);

	public static Inventory CreateInventory(List<Gear> gear, int healingPotionsAmount = 1)
	{
		List<Item> itemList = new();

		for (int i = 0; i < healingPotionsAmount; i++)	itemList.Add(new HealingPotion());

		foreach (Gear g in gear) itemList.Add(g);

		return new Inventory(itemList);
	}

	public override string ToString()
	{
		return Name;
	}
}
