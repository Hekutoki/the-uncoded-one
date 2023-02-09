using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Items;

class Gear : Item
{
	public Attack Attack { get; }

	public Gear(string name, Attack attack) : base(name) { Attack = attack; }

	public override void Use(Character targetCharacter)
	{
		throw new NotImplementedException();
	}
}
