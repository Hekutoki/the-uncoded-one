using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Attacks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items.Consumables;

namespace TheUncodedOne.Items.Gear;

class Gear
{
    public string Name { get; }
    public Attack Attack { get; }

    public Gear(string name, Attack attack)
    {
        Name = name;
        Attack = attack;
    }

    public override string ToString() => Name;
}
