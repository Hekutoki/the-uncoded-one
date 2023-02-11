namespace TheUncodedOne;

class BattleSeries
{
	private Party _heroParty;
	private bool _heroPartyAlive => _heroParty.Characters.Count > 0;

	public BattleSeries(Party heroParty) { _heroParty = heroParty; }

	public void Run(List<Party> monsterParties)
	{
		foreach(Party monsterParty in monsterParties)
		{
			Battle battle = new(_heroParty, monsterParty);
			battle.Run();

			if (_heroPartyAlive)
			{
				Console.WriteLine("Heroes defeated the monster party!");
			}
			else
			{
				Console.WriteLine("Hereoes lost and the Ucoded One's forces have prevailed...");
				break; 
			}

			Console.WriteLine("");
		}

		if (_heroPartyAlive) Console.WriteLine("Heroes won and the Uncoded One has been defeated!");
	}

}
