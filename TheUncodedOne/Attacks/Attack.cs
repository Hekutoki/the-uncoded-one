using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Attacks;

abstract class Attack
{
    public string Name { get; }

    public Attack(string name) { Name = name; }

    public abstract int GetDamage();

    public override string ToString()
    {
        return Name;
    }
}
