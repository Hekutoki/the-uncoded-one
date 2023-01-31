using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Attacks;

class BoneCrunch : Attack
{
	private Random random = new();

	public BoneCrunch() : base("BONE CRUNCH") { }

	public override int GetDamage() => random.Next(2);
}
