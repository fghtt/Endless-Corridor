using UnityEngine;

public class PickUpObjectInteraction : Interaction
{
    [SerializeField]
    private PickingUpAction _pickingUpAction;

    public override void Interact()
    {
        _pickingUpAction.PerformAnAction();
        gameObject.SetActive(false);
    }
}