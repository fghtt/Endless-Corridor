using UnityEngine;

public class ShowTextWindowInteraction : Interaction
{
	[SerializeField]
	private TextWindow _window;

	[SerializeField]
	private int _id;

	public override void Interact()
	{
		_window.Show(_id);
	}
}