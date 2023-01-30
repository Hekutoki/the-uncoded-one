using TheUncodedOne;
using TheUncodedOne.Characters;

Player trueProgrammer = new();
Skeleton monsterSkeleton = new();

Party heroParty = new("Heroes", new List<Character> { trueProgrammer, new Skeleton("BIGGEST BOI") });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton, new Skeleton("GOODEST BOI")});

Battle battle = new(heroParty, monsterParty);

Console.WriteLine("Let the battle begin!");
battle.Run();
