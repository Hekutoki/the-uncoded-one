using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Actions;

interface IAction
{
    public void PerformAction(Character performingCharacter);
}
