using System.Collections.ObjectModel;
using TheUncodedOne.Characters;
using TheUncodedOne.Items.Consumables;
using TheUncodedOne.Items.Gear;

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
		List<Consumable> consumableList = new();
		List<Gear> gearList = new();

		for (int i = 0; i < healingPotionsAmount; i++) consumableList.Add(new HealingPotion());
		for (int i = 0; i < gear.Count; i++) gearList.Add(gear[i]);

		return new Inventory(consumableList, gearList);
	}

	public override string ToString()
	{
		return Name;
	}
}
