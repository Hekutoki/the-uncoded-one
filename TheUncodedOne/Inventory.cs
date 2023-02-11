using TheUncodedOne.Items.Consumables;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne;

class Inventory
{
	public List<Consumable> Consumables { get; } = new();
	public List<Gear> Gear { get; } = new();

	public Inventory(List<Consumable> consumables, List<Gear> gear)
	{
		Consumables = consumables.Where(i => i != null).ToList();
		Gear = gear.Where(i => i != null).ToList();
	}

	public bool ContainsByName(Consumable item) => Consumables.Any(i => i.Name == item.Name);
	public bool ConsumablesAvailable() => Consumables.Count > 0;
	public bool GearAvailable() => Gear.Count > 0;

}
