using UnityEngine;

public class DeactivateObjectAction : CustomAction.Action
{
    [SerializeField]
    private GameObject _object;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public override void DoAction()
    {
        _object.SetActive(false);
    }
}