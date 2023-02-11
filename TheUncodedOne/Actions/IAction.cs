using TheUncodedOne.Characters;

namespace TheUncodedOne.Actions;

interface IAction
{
	public string Name { get; }
	public void Perform(Character performingCharacter, Battle battle);
}
