using UnityEngine;

public class ReplicaBeforeInteraction : ActionBeforeInteraction
{
    [SerializeField]
    private Replica _replica;

    [SerializeField]
    private int _replicaId;

    [SerializeField]
    private ActionBeforeInteractionCondition _actionBeforeInteractionCondition;

    public override void DoAction()
    {
        _replica.ShowReplica(_replicaId);
    }

    public override bool CanInteract()
    {
        return _actionBeforeInteractionCondition.CanInteract();
    }
}