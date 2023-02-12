using TheUncodedOne.Characters;
using TheUncodedOne.Items.Consumables;
using TheUncodedOne.Items.Gear;

namespace TheUncodedOne;

class Battle
{
	public Party HeroParty;
	public Party MonsterParty;
	private bool _isHeroesTurn = true;
	private int _nextActionDelay = 1000;

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

		if (HeroParty.Characters.Count > 0) TransferLoot();
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

	private void TransferLoot()
	{
		List<string> lootList = new();

		foreach (Gear gear in MonsterParty.Inventory.Gear)
		{
			HeroParty.Inventory.Gear.Add(gear);
			lootList.Add(gear.Name);
		}

		foreach (Consumable consumable in MonsterParty.Inventory.Consumables)
		{
			HeroParty.Inventory.Consumables.Add(consumable);
			lootList.Add(consumable.Name);
		}

		if (lootList.Count > 0)
		{
			Console.WriteLine("You steal defeated enemies' items.");
			foreach (string item in lootList) Console.WriteLine($"- {item}");

			Console.WriteLine("");
		}
	}
}
