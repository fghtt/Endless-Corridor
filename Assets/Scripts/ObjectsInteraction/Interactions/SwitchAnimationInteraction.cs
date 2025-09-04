using UnityEngine;

public class SwitchAnimationInteraction : Interaction
{
	[SerializeField]
	private string _firstTrigger;

	[SerializeField]
	private string _secondTrigger;

	private string _lastTrigger;

	private Animator _animator;

    private void Start()
    {
		_animator = GetComponent<Animator>();
    }

	public override void Interact()
	{
		string trigger = _firstTrigger;

		if (_lastTrigger == _firstTrigger)
			trigger = _secondTrigger;

        _animator.SetTrigger(trigger);
		_lastTrigger = trigger;
    }
}