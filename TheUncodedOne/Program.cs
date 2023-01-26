using TheUncodedOne;
using TheUncodedOne.Actions;

Character heroSkeleton = new("SKELETON", new DoNothingAction());
Character monsterSkeleton = new("SKELETON", new DoNothingAction());

Party heroParty = new("Heroes", new List<Character> { heroSkeleton });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton});

Battle battle = new(heroParty, monsterParty);

Console.WriteLine("Let the battle begin!");
battle.Run();
