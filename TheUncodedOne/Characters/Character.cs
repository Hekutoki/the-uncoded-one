using System.Reflection.Metadata;
using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;

namespace TheUncodedOne.Characters;

abstract class Character
{
    public string Name { get; }
    public int MaxHealth { get; }
    public int Health { get; protected set; }
    public bool IsNPC { get; }
    public List<IAction> Actions { get; }
    public List<Attack> Attacks { get; }

    private Random _random = new();

    public Character(string name, List<IAction> actions, List<Attack> attacks, int maxHealth, bool isNPC = true)
    {
        Name = name;
        MaxHealth = maxHealth;
        Health = MaxHealth;
        IsNPC = isNPC;

        Actions = actions.Where(a => a != null).ToList();
        Attacks = attacks;
	}

    public virtual void PerformAction(Battle battle)
    {
        if (IsNPC) 
        {
            IAction? attackAction = Actions.Where(a => a is AttackAction).First();

            if (attackAction == null) Actions[0].Perform(this, battle);
            else attackAction.Perform(this, battle);
        }
		else
		{
			User.DisplayActions(Actions);
			int userNumber = User.GetNumber("What do you do?", Actions.Count);

			Actions[userNumber].Perform(this, battle);
		}
	}

    public virtual Attack ChooseAttack()
    {
		if (IsNPC) return Attacks[_random.Next(Attacks.Count)];

		User.DisplayAttacks(Attacks);
		int userNumber = User.GetNumber("What attack do you choose?", Attacks.Count);

		return Attacks[userNumber];
	}

    public virtual Character ChooseTarget(Battle battle)
    {
		Party enemyParty = battle.GetEnemyParty(this);
		int characterCount = enemyParty.Characters.Count;

		if (IsNPC) return enemyParty.Characters[_random.Next(characterCount)];

		User.DisplayTargets(enemyParty.Characters);
		int userNumber = User.GetNumber("Who is your target?", characterCount);

		return enemyParty.Characters[userNumber];
	}

    public virtual void TakeDamage(int damageAmount) 
    {
        if (Health > 0) Health -= damageAmount;

        if (Health < 0) Health = 0;
    }
}
