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


}
