using UnityEngine;

public class BeforeExitStartRoomInteractionCondition :
    ActionBeforeInteractionCondition
{
    [SerializeField]
    private FlashlightPickingUpAction _flashlightPickingUp;

    [SerializeField]
    private ReadNoteInteraction _notePickingUp;

    public override bool CanInteract()
    {
        return _flashlightPickingUp.IsPickedUp && _notePickingUp.WasPickedUp;
    }
}