using TheUncodedOne;
using TheUncodedOne.Characters;

int gameMode = User.GetNumber("Choose your gameplay mode." +
	"\n0 -> computer vs computer" +
	"\n1 -> player vs computer " +
	"\n2 -> player vs player", 3);

(bool isHeronPlayable, bool isMonsterPlayable) = gameMode switch
{
	1 => (true, false),
	2 => (true, true),
	_ => (false, false)
};

Party heroParty = new("Heroes", new List<Character> { new TrueProgrammer(isHeronPlayable), new Skeleton("skelly", isHeronPlayable) });
Party monsterParty1 = new("Monsters", new List<Character> { new Skeleton("SCHWING", isMonsterPlayable) });
Party monsterParty2 = new("Monsters", new List<Character> { new Skeleton("BOOM", isMonsterPlayable), new Skeleton("BIG BADDY", isMonsterPlayable) });
Party monsterParty3 = new("Monsters", new List<Character> { new UncodedOne(isNPC: isMonsterPlayable) });

BattleSeries battles = new(heroParty);

battles.Run(new List<Party> { monsterParty1, monsterParty2, monsterParty3 });


