using UnityEngine;

public class FlashlightPickingUpAction : PickingUpAction
{
	[SerializeField]
	private GameObject _flashlight;

	private bool _isPickedUp;
	public bool IsPickedUp => _isPickedUp;

	public override void PerformAnAction()
	{
		_isPickedUp = true;
        _flashlight.gameObject.SetActive(true);
	}
}