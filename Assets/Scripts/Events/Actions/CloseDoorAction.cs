using UnityEngine;

public class CloseDoorAction : CustomAction.Action
{
    [SerializeField]
    private Animator _doorAnimator;

    private const string CLOSE_DOOR_TRIGGER = "Close";

    private bool _didNotDone = false;

    public override void DoAction()
    {
        if (_didNotDone)
        {
            _doorAnimator.SetTrigger(CLOSE_DOOR_TRIGGER);
            _didNotDone = false;
        }
    }

    public void Activate()
    {
        _didNotDone = true;
    }
}