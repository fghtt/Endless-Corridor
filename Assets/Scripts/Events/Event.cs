using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    private CustomAction.Action[] _actions;

    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER_TAG)
        {
            foreach (CustomAction.Action action in _actions)
            {
                action.DoAction();
            }
        }
    }
}