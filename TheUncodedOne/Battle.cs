using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class Battle
{
	public readonly Party HeroParty;
	public readonly Party MonsterParty;
	private bool _isHeroesTurn = true;

	public int TurnCount { get; private set; }

	public Battle(Party heroParty, Party monsterParty)
	{
		TurnCount = 1;

		HeroParty = heroParty;
		MonsterParty = monsterParty;
	}

	// Main game loop
	public void Run()
	{
		while (true)
		{
			if (_isHeroesTurn) PerformActions(HeroParty);
			else PerformActions(MonsterParty);

			_isHeroesTurn = !_isHeroesTurn;
		}
	}

	// Gives party allied to given character
	public Party GetAllyParty(Character character)
	{
		foreach (Character heroChar in HeroParty.Characters)
		{
			if (heroChar == character) return HeroParty;
		}
		return MonsterParty;
	}

	// Gives enemy party of given character
	public Party GetEnemyParty(Character character)
	{
		foreach (Character heroChar in HeroParty.Characters)
		{
			if (heroChar == character) return MonsterParty;
		}
		return HeroParty;
	}

	private void PerformActions(Party party)
	{
		foreach (Character character in party.Characters)
		{
			Console.WriteLine($"It is {character.Name}'s turn...");

			character.PerformAction(this);

			// Empty line for differentiating between turns
			Console.WriteLine("");
			Thread.Sleep(1000);
		}
	}
}
