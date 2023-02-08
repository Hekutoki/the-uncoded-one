using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;
using TheUncodedOne.Items;

namespace TheUncodedOne.Characters;

abstract class Character
{
	public string Name { get; }
	public int MaxHealth { get; }
	private int _health;
	public int Health 
	{
		get => _health;
		set 
		{
			_health = value;
			if (_health > MaxHealth) _health = MaxHealth;
			if (_health < 0) _health = 0;
		}
	}

	public bool IsPlayable { get; }
	public Intent Intent { get; private set; } = Intent.Nothing;
	public List<IAction> Actions { get; }
	public List<Attack> Attacks { get; }

	private readonly Random _random = new();

	public Character(string name, List<Attack> attacks, int maxHealth, bool isPlayable = true)
	{
		Name = name;
		MaxHealth = maxHealth;
		Health = MaxHealth;
		IsPlayable = isPlayable;

		Actions = CreateActions();
		Attacks = attacks;
	}

	public virtual void PerformAction(Battle battle)
	{
		Intent = Intent.Nothing;

		if (!IsPlayable) GetAIAction(battle).Perform(this, battle);
		else
		{
			User.DisplayActions(Actions);
			int userChoice = User.GetNumber("What do you do?", Actions.Count);

			Actions[userChoice].Perform(this, battle);
		}
	}

	public virtual Attack ChooseAttack()
	{
		if (!IsPlayable) return Attacks[_random.Next(Attacks.Count)];

		User.DisplayAttacks(Attacks);
		int userChoice = User.GetNumber("What attack do you choose?", Attacks.Count);

		return Attacks[userChoice];
	}

	public virtual Item ChooseItem(Party party)
	{
		var items = party.Inventory.Items;

		if (!IsPlayable) return items[0];

		User.DisplayItems(items);
		int userChoice = User.GetNumber("What item do you choose?", items.Count);

		return items[userChoice];
	}

	public virtual Character ChooseTarget(Battle battle, bool isEnemy = true)
	{
		Party targetParty;
		if (isEnemy) targetParty = battle.GetEnemyParty(this);
		else targetParty = battle.GetAllyParty(this);

		int characterCount = targetParty.Characters.Count;

		if (!IsPlayable) return targetParty.Characters[_random.Next(characterCount)];

		User.DisplayTargets(targetParty.Characters);
		int userNumber = User.GetNumber("Who is your target?", characterCount);

		return targetParty.Characters[userNumber];
	}

	public static List<IAction> CreateActions() => new List<IAction>() { new DoNothingAction(), new AttackAction(), new UseItemAction() };

	public override string ToString()
	{
		return Name;
	}

	private IAction GetAIAction(Battle battle)
	{
		bool isHealingAvailable = battle.GetAllyParty(this).Inventory.ContainsByName(new HealingPotion());
		bool isHealthLow = ((float)Health / MaxHealth) < 0.25f;

		if (_random.Next(4) == 3 && isHealingAvailable && isHealthLow )
		{
			IAction? useItem = Actions.Where(a => a is UseItemAction).First();
			Intent = Intent.Heal;

			if (useItem != null) return useItem; 
		}

		IAction? attackAction = Actions.Where(a => a is AttackAction).First();

		if (attackAction == null) return Actions[0];
		else return attackAction;
	}

}

public enum Intent { Nothing, Attack, Heal }