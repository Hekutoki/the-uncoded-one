using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class BattleStatus
{
	private static string _header = "==================== BATTLE =========================";
	private static string _divider = "-------------------- VS -----------------------------";
	private static string _footer = "=====================================================";

	public static void Display(Battle battle, Character activeCharacter)
	{
		List<Character> heroCharacters = battle.HeroParty.Characters.ToList();
		List<Character> monsterCharacters = battle.MonsterParty.Characters.ToList();

		Console.WriteLine(_header);

		DisplayCharacters(heroCharacters, activeCharacter, false);

		Console.WriteLine(_divider);

		DisplayCharacters(monsterCharacters, activeCharacter, true);

		Console.WriteLine(_footer);
	}

	private static string GetFormattedHealth(Character character) => $"( {character.Health}/{character.MaxHealth} )";

	private static void DisplayCharacters(List<Character> characters, Character activeCharacter, bool alignToLeft)
	{
		foreach (Character character in characters)
		{
			if (character == activeCharacter) Console.ForegroundColor = ConsoleColor.Magenta;

			if (alignToLeft)
				Console.WriteLine($"{character,40} {GetFormattedHealth(character),10}");
			else
				Console.WriteLine($"{character,-10} {GetFormattedHealth(character)}");

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
