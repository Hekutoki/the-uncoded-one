using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Attacks;

class Punch : Attack
{
	public Punch() : base("PUNCH") { }

	public override int GetDamage() => 1;
}
