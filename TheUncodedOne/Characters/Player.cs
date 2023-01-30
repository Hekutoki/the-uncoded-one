using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using static System.Collections.Specialized.BitVector32;

namespace TheUncodedOne.Characters;

class Player : Character
{
    public Player() : base(GetName(), 
        new List<IAction>() { new DoNothingAction(), new AttackAction() },
        new List<Attack>() { new Attack("PUNCH") }) { }

    public static string GetName()
    {
        string name = "";
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("What's your name, Programmer?");
            name = Console.ReadLine();
        }

        Console.Clear();

        return name;
    }

    public override void PerformAction(Battle battle)
    {
        // Get input from user
        GetAction().Perform(this, battle);

        //Actions[0].PerformAction(this);
    }

    private IAction GetAction()
    {
        int userInput;
        IAction action;

		for (int i = 0; i < Actions.Count; i++)
		{
            Console.WriteLine(i + " <--- " + Actions[i].Name);
		}

		while (true)
        {
            Console.Write("Pick the action number: ");

            // If can't parse input, continue
            if (!int.TryParse(Console.ReadLine(), out userInput)) continue;
            else if (userInput < 0 || userInput >= Actions.Count) continue;

            break;
        }

		for (int i = 0; i < Actions.Count; i++)
		{
            if (i == userInput)
            {
                action = Actions[i];
                return action;
            }
		}

        // Number somehow doesn't match any action
		return new DoNothingAction();
    }

    public override Attack ChooseAttack()
    {
		int userInput;
        Attack attack;

		for (int i = 0; i < Attacks.Count; i++)
		{
			Console.WriteLine(i + " <--- " + Attacks[i].Name);
		}

		while (true)
		{
			Console.Write("Pick the attack number: ");

			// If can't parse input, continue
			if (!int.TryParse(Console.ReadLine(), out userInput)) continue;
			else if (userInput < 0 || userInput >= Attacks.Count) continue;

			break;
		}

		for (int i = 0; i < Actions.Count; i++)
        {
			if (i == userInput)
			{
				attack = Attacks[i];
				return attack;
			}
		}

        return Attacks[0];
	}

    public override Character ChooseTarget(Battle battle)
    {
        Party enemyParty = battle.GetEnemyParty(this);
        int charactersCount = enemyParty.Characters.Count;

        return enemyParty.Characters[new Random().Next(charactersCount)];
    }

    public override void TakeDamage(int damageAmount)
    {
        throw new NotImplementedException();
    }
}
