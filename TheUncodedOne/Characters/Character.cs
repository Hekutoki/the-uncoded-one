using TheUncodedOne.Actions;
using TheUncodedOne.Attacks;
using TheUncodedOne.Items.Consumables;
using TheUncodedOne.Items.Gear;

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

	public Gear? EquippedGear { get; private set; }
	public bool IsPlayable { get; }
	public ItemIntent Intent { get; private set; } = ItemIntent.Nothing;

	public List<IAction> Actions { get; }
	public List<Attack> Attacks { get; }

	private readonly Random _random = new();

	public Character(string name, List<Attack> attacks, int maxHealth, bool isPlayable = true, Gear? gear = null)
	{
		Name = name;
		MaxHealth = maxHealth;
		Health = MaxHealth;
		IsPlayable = isPlayable;
		EquippedGear = gear;

		Actions = CreateActions();
		Attacks = attacks;

		if (EquippedGear != null) Attacks.Add(EquippedGear.Attack);
	}

	public virtual void PerformAction(Battle battle)
	{
		Intent = ItemIntent.Nothing;

		if (!IsPlayable) GetAIAction(battle).Perform(this, battle);
		else
		{
			User.DisplayActions(GetAvailableActions(battle));
			int userChoice = User.GetNumber("What do you do?", Actions.Count);

			Actions[userChoice].Perform(this, battle);
		}
	}

	public virtual Attack ChooseAttack()
	{
		if (!IsPlayable) return GetAIAttack();

		User.DisplayAttacks(Attacks);
		int userChoice = User.GetNumber("What attack do you choose?", Attacks.Count);

		return Attacks[userChoice];
	}

	public virtual Consumable ChooseItem(Party party)
	{
		List<Consumable> item = party.Inventory.Consumables;

		if (!IsPlayable) return item[0];

		User.DisplayConsumables(item);
		int userChoice = User.GetNumber("What item do you choose?", item.Count);

		return item[userChoice];
	}

	public virtual Gear ChooseGear(Party party)
	{
		List<Gear> inventoryGear = party.Inventory.Gear;

		if (!IsPlayable) return inventoryGear[0];

		User.DisplayGear(inventoryGear);
		int userChoice = User.GetNumber("What gear piece do you choose?", inventoryGear.Count);

		return inventoryGear[userChoice];
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

	public virtual Gear? EquipGear(Gear gear)
	{
		Gear? oldGear = null;

		if (EquippedGear == null) EquippedGear = gear;
		else
		{
			Attacks.Remove(EquippedGear.Attack);
			oldGear = EquippedGear;
			EquippedGear = gear;
		}

		Attacks.Add(EquippedGear.Attack);
		return oldGear;
	}

	public static List<IAction> CreateActions() => new List<IAction>() { new DoNothingAction(), new AttackAction(), new UseConsumableAction(), new EquipGearAction() };

	public override string ToString()
	{
		return Name;
	}

	private IAction GetAIAction(Battle battle)
	{
		Inventory inventory = battle.GetAllyParty(this).Inventory;

		bool isHealingAvailable = inventory.ContainsByName(new HealingPotion());
		bool isGearAvailable = inventory.GearAvailable();
		bool isHealthLow = ((float)Health / MaxHealth) < 0.25f;

		if (_random.Next(4) == 0 && isHealingAvailable && isHealthLow )
		{
			IAction? useItem = Actions.OfType<UseConsumableAction>().First();
			Intent = ItemIntent.Heal;

			if (useItem != null) return useItem; 
		}

		if (_random.Next(2) == 0 && EquippedGear == null && isGearAvailable)
		{
			IAction? equipGear = Actions.OfType<EquipGearAction>().First();

			if (equipGear != null) return equipGear;
		}

		IAction? attackAction = Actions.Where(a => a is AttackAction).First();

		if (attackAction == null) return Actions[0];
		else return attackAction;
	}

	private Attack GetAIAttack()
	{
		var specialAttacks = Attacks.Where(a => a.IsSpecial == true);
		
		if (specialAttacks.Any())
			return specialAttacks.ToList()[_random.Next(specialAttacks.Count())];

		return Attacks[_random.Next(Attacks.Count)];
	}

	private List<IAction> GetAvailableActions(Battle battle)
	{
		List<IAction> availables = new(Actions);

		Inventory inventory = battle.GetAllyParty(this).Inventory;

		if (!inventory.ConsumablesAvailable())
		{
			UseConsumableAction action = availables.OfType<UseConsumableAction>().First();
			availables.Remove(action);
		}

		if (!inventory.GearAvailable())
		{
			EquipGearAction action = availables.OfType<EquipGearAction>().First();
			availables.Remove(action);
		}

		return availables;
	}
}

public enum ItemIntent { Nothing, Heal }