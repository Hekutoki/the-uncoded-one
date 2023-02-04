using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class Battle
{
	public Party HeroParty;
	public Party MonsterParty;
	private bool _isHeroesTurn = true;
	private int _nextActionDelay = 2000;

	public int TurnCount { get; private set; }

	public Battle(Party heroParty, Party monsterParty)
	{
		TurnCount = 1;

		HeroParty = heroParty;
		MonsterParty = monsterParty;
	}

	public void CreateNew(Party heroParty, Party monsterParty)
	{
		TurnCount = 1;

		HeroParty = heroParty;
		MonsterParty = monsterParty;
	}

	public void Run()
	{
		while (true)
		{
			if (IsBattleOver()) break;

			if (_isHeroesTurn) PerformActions(HeroParty);
			else PerformActions(MonsterParty);

			_isHeroesTurn = !_isHeroesTurn;
		}
	}

	public Party GetAllyParty(Character character)
	{
		foreach (Character heroChar in HeroParty.Characters)
		{
			if (heroChar == character) return HeroParty;
		}
		return MonsterParty;
	}

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
			if (IsBattleOver()) return;

			Console.WriteLine($"It is {character}'s turn...");
			BattleStatus.Display(this, character);

			character.PerformAction(this);

			// Empty line for differentiating between turns
			Console.WriteLine("");
			Thread.Sleep(_nextActionDelay);
		}
	}

	private bool IsBattleOver()
	{
		bool isAnyPartyEmpty = HeroParty.Characters.Count == 0 || MonsterParty.Characters.Count == 0;

		return isAnyPartyEmpty;
	}
}
