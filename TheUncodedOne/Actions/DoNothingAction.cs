using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Actions;

internal class DoNothingAction : IAction
{
	public void PerformAction(Character performingCharacter)
	{
		Console.WriteLine($"{performingCharacter.Name} did nothing.");
	}
}
