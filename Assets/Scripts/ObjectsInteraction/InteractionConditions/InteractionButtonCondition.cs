using UnityEngine;

public class InteractionButtonCondition : InteractionCondition
{
    public override bool Check()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}