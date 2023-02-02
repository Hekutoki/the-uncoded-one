using TheUncodedOne;
using TheUncodedOne.Characters;

TrueProgrammer trueProgrammer = new();
Skeleton monsterSkeleton = new();

Party heroParty = new("Heroes", new List<Character> { trueProgrammer, new Skeleton("skelly") });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton });

Battle battle = new(heroParty, monsterParty);

battle.Run();
