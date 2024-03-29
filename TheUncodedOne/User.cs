﻿using System.Collections.ObjectModel;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;
using TheUncodedOne.Characters;
using TheUncodedOne.Items.Consumables;
using TheUncodedOne.Items.Gear;

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

	// Gets number from user with exclusive upper bound
	public static int GetNumber(string prompt, int max)
	{
		int userAnswer;
		while (true)
		{
			Console.WriteLine(prompt);
			if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer < max) break;
		}

		return userAnswer;
	}

	public static void DisplayActions(List<IAction> actions)
	{
		for (int i = 0; i < actions.Count; i++) Console.WriteLine(i + " ---> " + actions[i]);
	}

	public static void DisplayAttacks(List<Attack> attacks)
	{
		for (int i = 0; i < attacks.Count; i++) Console.WriteLine(i + " ---> " + attacks[i]);
	}

	public static void DisplayConsumables(List<Consumable> consumables)
	{
		for (int i = 0; i < consumables.Count; i++) Console.WriteLine($"{i} ---> {consumables[i]}");
	}

	public static void DisplayGear(List<Gear> gear)
	{
		for (int i = 0; i < gear.Count; i++) Console.WriteLine($"{i} ---> {gear[i]}");
	}

	public static void DisplayTargets(ReadOnlyCollection<Character> characters)
	{
		for (int i = 0; i < characters.Count; i++) Console.WriteLine($"{i} ---> {characters[i]}");
	}
}
