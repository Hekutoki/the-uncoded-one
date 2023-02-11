using TheUncodedOne.Characters;

namespace TheUncodedOne;

class BattleStatus
{
	private static string _header = "================================= BATTLE =================================";
	private static string _divider = "----------------------------------- VS -----------------------------------";
	private static string _footer = "==========================================================================";

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
				Console.WriteLine($"{character,50} {GetFormattedHealth(character),10} {character.EquippedGear,10}");
			else
				Console.WriteLine($"{character,-10} {GetFormattedHealth(character)} {character.EquippedGear,-10}");

			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
