using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Actions;

namespace TheUncodedOne.Characters;

class Player : Character
{
    public override string Name { get; init; }
    public override List<IAction> Actions { get; }

    public Player() : base(GetName(), new List<IAction>() { new DoNothingAction() }) { }

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

    public override void PerformAction()
    {
        // Get input from user
        Actions[0].PerformAction(this);
    }

    public override void TakeDamage(int damageAmount)
    {
        throw new NotImplementedException();
    }
}
