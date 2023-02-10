using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Items.Consumables;

class HealingPotion : Consumable
{
    public HealingPotion() : base("Healing Potion") { }

    public override void Use(Character targetCharacter)
    {
        targetCharacter.Health += 10;
    }
}
