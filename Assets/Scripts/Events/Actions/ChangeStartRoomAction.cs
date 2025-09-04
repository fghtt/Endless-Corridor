using UnityEngine;
 
public class ChangeStartRoomAction : CustomAction.Action
{
    [SerializeField]
    private StartRoom _startRoom;

    public override void DoAction()
    {
        _startRoom.MoveStartRoom();
    }
}