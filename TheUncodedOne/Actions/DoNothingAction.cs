using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

internal class DoNothingAction : IAction
{
	public string Name => "Do nothing";

	public void Perform(Character performingCharacter, Battle battle)
	{
		Console.WriteLine($"{performingCharacter.Name} did nothing.");
	}

	public override string ToString() => Name;
}
