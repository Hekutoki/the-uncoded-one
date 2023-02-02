using TheUncodedOne;
using TheUncodedOne.Characters;

Party heroParty = new("Heroes", new List<Character> { new TrueProgrammer(), new Skeleton("skelly") });
Party monsterParty1 = new("Monsters", new List<Character> { new Skeleton("SCHWING")});
Party monsterParty2 = new("Monsters", new List<Character> { new Skeleton("BOOM"), new Skeleton("BIG BADDY") });

BattleSeries battles = new(heroParty);

battles.Run(new List<Party> { monsterParty1, monsterParty2 });


