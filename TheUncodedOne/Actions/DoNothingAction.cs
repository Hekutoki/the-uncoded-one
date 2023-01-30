﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

internal class DoNothingAction : IAction
{
	public string Name => "Do nothing";

	public void Perform(Character performingCharacter)
	{
		Console.WriteLine($"{performingCharacter.Name} did nothing.");
	}
}
