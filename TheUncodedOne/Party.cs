using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class Party
{
	public string Name { get; }

	private List<Character> _characters = new();
	public ReadOnlyCollection<Character> Characters => _characters.AsReadOnly();

	public Party (string partyName, List<Character> characters)
	{
		Name = partyName;
		foreach(Character character in characters) { _characters.Add(character); }
	}

	public bool RemovePartyMember(Character character) => _characters.Remove(character);
}
