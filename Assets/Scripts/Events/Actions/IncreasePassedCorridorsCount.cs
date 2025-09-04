public class IncreasePassedCorridorsCountAction : CustomAction.Action
{
	private PassedCorridorsCount _passedCorridorsCount;

	public void SetPassedCorridorsCount(PassedCorridorsCount passedCorridorsCount)
	{
		_passedCorridorsCount = passedCorridorsCount;
	}

	public override void DoAction()
	{
		_passedCorridorsCount.IncreaseCount();
	}
}