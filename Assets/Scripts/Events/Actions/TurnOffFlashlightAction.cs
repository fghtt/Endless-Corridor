using UnityEngine;

public class TurnOffFlashlightAction : CustomAction.Action
{
    [SerializeField]
    private PlayerFlashlight _playerFlashlight;

    public override void DoAction()
    {
        _playerFlashlight.TurnOff();
    }

    public void SetPlayerFlashlight(GameObject player)
    {
        _playerFlashlight = player.GetComponent<PlayerFlashlight>();
    }
}