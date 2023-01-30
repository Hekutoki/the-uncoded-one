using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;
using TheUncodedOne.Characters;

namespace TheUncodedOne;

class User
{
    public static string GetString(string prompt)
    {
        string userAnswer = "";
        while (string.IsNullOrWhiteSpace(userAnswer))
        {
            Console.WriteLine(prompt);
            userAnswer = Console.ReadLine();
        }

        Console.Clear();

        return userAnswer;
    }

    // Gets number from user with exclusive biggest number
    public static int GetNumber(string prompt, int max)
    {
		int userAnswer;
		while (true)
		{
            Console.WriteLine(prompt);
            if (int.TryParse(Console.ReadLine(), out userAnswer))   break;
		}

		Console.Clear();

		return userAnswer;
	}

    public static void DisplayActions(List<IAction> actions)
    {
        for (int i = 0; i < actions.Count; i++)
        {
			Console.WriteLine(i + " ---> " + actions[i].Name);
		}
	}

	public static void DisplayAttacks(List<Attack> attacks)
	{
		for (int i = 0; i < attacks.Count; i++)
		{
			Console.WriteLine(i + " ---> " + attacks[i].Name);
		}
	}

    public static void DisplayTargets(List<Character> characters)
    {
		for (int i = 0; i < characters.Count; i++)
		{
			Console.WriteLine(i + " ---> " + characters[i].Name);
		}
	}
}
