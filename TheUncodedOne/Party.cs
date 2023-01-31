using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class Party
{
	public string Name { get; }
	public readonly List<Character> Characters = new();

	public Party (string partyName, List<Character> characters)
	{
		Name = partyName;
		foreach(Character character in characters) { Characters.Add(character); }
	}
}
