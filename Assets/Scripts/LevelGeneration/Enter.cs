using UnityEngine;

public class Enter : MonoBehaviour
{
    [SerializeField]
    private GameObject _closeDoorCollider;

    [SerializeField]
    private GameObject _levelGenerationCollider;

    [SerializeField]
    private GameObject _turnOffFlashlightCollider;

    [SerializeField]
    private CloseDoorAction _closeDoorAction;

    private InteractableObject _doorInteractableObject;

    private void Start()
    {
        _doorInteractableObject = GetComponentInChildren<InteractableObject>();
    }

    public void Activate()
    {
        _doorInteractableObject.Activate();
        _closeDoorCollider.SetActive(true);
        _levelGenerationCollider.SetActive(true);
        _turnOffFlashlightCollider.SetActive(true);
        _closeDoorAction.Activate();
    }
}