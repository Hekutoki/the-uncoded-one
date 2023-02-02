using TheUncodedOne;
using TheUncodedOne.Characters;

TrueProgrammer trueProgrammer = new();
Skeleton monsterSkeleton = new();

Party heroParty = new("Heroes", new List<Character> { trueProgrammer, new Skeleton("skelly") });
Party monsterParty1 = new("Monsters", new List<Character> { monsterSkeleton });
Party monsterParty2 = new("Monsters", new List<Character> { monsterSkeleton, new Skeleton("BIG BADDY") });

Battle battle1 = new(heroParty, monsterParty1);
Battle battle2 = new(heroParty, monsterParty2);

battle1.Run();
if (heroParty.Characters.Count > 0) battle2.Run();

if (heroParty.Characters.Count > 0)
{
	Console.WriteLine("Heroes won and the Uncoded One has been defeated!");
}



