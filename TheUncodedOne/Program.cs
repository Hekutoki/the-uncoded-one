using TheUncodedOne;
using TheUncodedOne.Characters;

TrueProgrammer trueProgrammer = new();
Skeleton monsterSkeleton = new();

Party heroParty = new("Heroes", new List<Character> { trueProgrammer, new Skeleton("BIGGEST BOI") });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton, new Skeleton("GOODEST BOI")});

Battle battle = new(heroParty, monsterParty);

battle.Run();
