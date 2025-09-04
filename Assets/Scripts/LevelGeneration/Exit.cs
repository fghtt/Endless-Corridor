using UnityEngine;

public class Exit : MonoBehaviour
{
	[SerializeField]
	private Transform _corridorPoint;
	public Transform CorridorPoint => _corridorPoint;

	[SerializeField]
	private GameObject _door;

	private DistanceCondition _distanceCondition;
	private InteractableObject _interactableObject;
	private CloseDoorAction _closeDoorAction;

    private void Start()
    {
		_interactableObject = GetComponentInChildren<InteractableObject>();
		_closeDoorAction = GetComponentInChildren<CloseDoorAction>();
		_closeDoorAction.Activate();
    }

    public void InitializeExit(GameObject player)
	{
        _distanceCondition = _door.GetComponentInChildren<DistanceCondition>();
        _distanceCondition.SetPlayer(player.transform);
	}

	public void Activate()
	{
		_interactableObject.Activate();
		_closeDoorAction.Activate();
	}
}