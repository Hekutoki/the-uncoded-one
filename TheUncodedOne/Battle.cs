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
	private Party _heroParty;
	private Party _monsterParty;
	private bool _isHeroesTurn = true;

	public int TurnCount { get; private set; }

	public Battle(Party heroParty, Party monsterParty)
	{
		TurnCount = 1;

		_heroParty = heroParty;
		_monsterParty = monsterParty;
	}

	// Main game loop
	public void Run()
	{
		while (true)
		{
			if (_isHeroesTurn) PerformActions(_heroParty);
			else PerformActions(_monsterParty);

			_isHeroesTurn = !_isHeroesTurn;
			Thread.Sleep(1000);
		}
	}

	private void PerformActions(Party party)
	{
		foreach (Character character in party.Characters)
		{
			Console.WriteLine($"It is {character.Name}'s turn...");

			character.PerformAction();

			// Empty line for differentiating between turns
			Console.WriteLine("");
		}
	}
}
