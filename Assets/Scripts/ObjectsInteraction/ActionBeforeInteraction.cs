using UnityEngine;

public abstract class ActionBeforeInteraction : MonoBehaviour
{
	public abstract void DoAction();

	public virtual bool CanInteract()
	{
		return true;
	}
}