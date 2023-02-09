using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Items;

namespace TheUncodedOne;

class Inventory
{
	private List<Item> _items = new();
	public ReadOnlyCollection<Item> Items => _items.AsReadOnly();

	public Inventory(List<Item> items) { _items = items.Where(i => i != null).ToList(); }

	public bool ContainsByName(Item item) => _items.Any(i => i.Name == item.Name);

	public List<Item> GetConsumables() => _items.Where(i => i is not Gear).ToList();

	public List<Gear> GetGear() => _items.OfType<Gear>().ToList();

	public void RemoveItem(Item item) { _items.Remove(item); }
	public void AddItem(Item item) { _items.Add(item); }
}
