using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Items.Gear;

internal class Dagger : Gear { public Dagger() : base("Dagger", new Stab()) { } }