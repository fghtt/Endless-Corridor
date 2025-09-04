using UnityEngine;

public class EnemyDoorOpeningAbility : MonoBehaviour
{
    private const string DOOR_TAG = "Door";

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}