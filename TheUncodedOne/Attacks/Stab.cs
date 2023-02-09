using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Attacks;

internal class Stab : Attack
{
	public Stab() : base("STAB") { }

	public override int GetDamage() => 1;
}
