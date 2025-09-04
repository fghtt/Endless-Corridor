using UnityEngine;

public class DeactivateAction : CustomAction.Action
{
    public override void DoAction()
    {
        gameObject.SetActive(false);
    }
}