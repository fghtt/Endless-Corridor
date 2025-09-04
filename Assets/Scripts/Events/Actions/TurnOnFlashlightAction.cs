using UnityEngine;

public class TurnOnFlashlightAction : CustomAction.Action
{
    [SerializeField]
    private PlayerFlashlight _playerFlashlight;

    public override void DoAction()
    {
        _playerFlashlight.TurnOn();
    }
}