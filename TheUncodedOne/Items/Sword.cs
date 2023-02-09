using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Items;

internal class Sword : Gear { public Sword() : base("Sword", new Slash()) { } }
