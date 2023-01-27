using TheUncodedOne;
using TheUncodedOne.Actions;

Character trueProgrammer = new(Player.GetName(), new DoNothingAction());
Character monsterSkeleton = new("SKELETON", new DoNothingAction());

Party heroParty = new("Heroes", new List<Character> { trueProgrammer });
Party monsterParty = new("Monsters", new List<Character> { monsterSkeleton});

Battle battle = new(heroParty, monsterParty);

Console.WriteLine("Let the battle begin!");
battle.Run();
