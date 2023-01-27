using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne;

class Player
{
	public static string GetName()
	{
		string name = "";
		while (string.IsNullOrWhiteSpace(name))
		{
			Console.WriteLine("What's your name, Programmer?");
			name = Console.ReadLine(); 
		}

		return name;
	}
}
