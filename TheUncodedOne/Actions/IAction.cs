using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

interface IAction
{
    public string Name { get; }
    public void PerformAction(Character performingCharacter);
}
