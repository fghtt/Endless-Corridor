using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
	private Animator _animator;
	private float _passedTime;
	private float _changingTriggerDelay = 0.25f;
	private List<string> _triggersOrders = new List<string>();

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

    public void Update()
    {
		if (_passedTime > 0) _passedTime -= Time.deltaTime;

        if (_triggersOrders.Count > 0 && _passedTime <= 0)
		{
			SetTrigger(_triggersOrders[0]);
			_triggersOrders.RemoveAt(0);
        }
    }

    public void SetTrigger(string trigger)
	{
		if (_passedTime <= 0)
		{
            _animator.SetTrigger(trigger);
            _passedTime = _changingTriggerDelay;				 
        } else
		{
			_triggersOrders.Add(trigger);
		}
	}
}