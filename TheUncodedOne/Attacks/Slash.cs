using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Attacks;

class Slash : Attack
{
	public Slash() : base("SLASH") { }

	public override int GetDamage() => 2;
}
