namespace TheUncodedOne;

public struct AttackModifier
{
	public int DamageChange { get; }
	public string Message => $"{_cause} {ReducedOrBoosted()} the attack damage by {Math.Abs(DamageChange)} point";
	private string _cause;

	public AttackModifier(int damageChange, string modifierCause)
	{
		DamageChange = damageChange;
		_cause = modifierCause;
	}

	private string ReducedOrBoosted() => DamageChange >= 0 ? "boosted" : "reduced";
}
