using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Items;

abstract class Item
{
	public string Name { get; }

	public Item(string name) { Name = name; }

	public abstract void Use();
}
