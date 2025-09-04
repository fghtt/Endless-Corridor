using UnityEngine;
using System.Collections.Generic;

public class InteractableObject : MonoBehaviour
{
	[SerializeField]
	private List<InteractionCondition> _conditions;

    [SerializeField]
    private Interaction _interaction;
    public Interaction Interaction => _interaction;

    [SerializeField]
    private InteractionButtonCondition _interactionButtonCondition;

    [SerializeField]
    private ActionBeforeInteraction _actionBeforeInteraction;
    public ActionBeforeInteraction ActionBeforeInteraction
        => _actionBeforeInteraction;

    [SerializeField]
    private bool _canInteractOnce;
    public bool CanInteractOnce => _canInteractOnce;

    [SerializeField]
    private bool _wasInteracted;
    public bool WasInteracted => _wasInteracted;

    public bool CheckConditions()
    {
        foreach (InteractionCondition condition in _conditions)
        {
            if (condition.Check())
                continue;

            return false;
        }

        return true;
    }

    public bool CheckButtonCondition()
    {
        return _interactionButtonCondition.Check();
    }

    public void ChangeStatus()
    {
        _wasInteracted = true;
    }

    public void Activate()
    {
        _wasInteracted = false;
    }
}