using TheUncodedOne;
using TheUncodedOne.Characters;

Player trueProgrammer = new();
Skeleton monsterSkeleton = new();

Party heroParty = new("Heroes", new List<Character> { trueProgrammer });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton});

Battle battle = new(heroParty, monsterParty);

Console.WriteLine("Let the battle begin!");
battle.Run();
