using UnityEngine;

public class Sight : MonoBehaviour
{
	[SerializeField]
	private float _distance;

    [SerializeField]
    private InteractionIcon _interactionIcon;

    [SerializeField]
    private InteractableObjectTitleUi _interactableObjectTitle;

    private PlayerController _playerController;

    private const string INTERCTABLE_OBJECT_TAG = "Interactable object";

    private void Awake()
    {
        _playerController = transform.parent.parent
            .GetComponent<PlayerController>();
    }

    private void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward,
            _distance);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider != null && hit.collider.tag == INTERCTABLE_OBJECT_TAG
            && _playerController.CanControlling)
            {
                InteractableObject interactableObject =
                    hit.collider.GetComponent<InteractableObject>();

                InteractableObjectTitle interactableObjectTitle =
                    hit.collider.GetComponent<InteractableObjectTitle>();

                if (interactableObjectTitle != null)
                {
                    string title = interactableObjectTitle.FindTitle();
                    _interactableObjectTitle.Show(title);
                }

                if (interactableObject.CanInteractOnce &&
                    interactableObject.WasInteracted)
                    return;

                if (interactableObject.CheckConditions())
                {
                    _interactionIcon.Show();
                    if (interactableObject.CheckButtonCondition())
                    {
                        if (interactableObject.ActionBeforeInteraction != null
                            && !interactableObject
                            .ActionBeforeInteraction.CanInteract())
                        {
                            interactableObject
                            .ActionBeforeInteraction.DoAction();
                            return;
                        }
                        interactableObject.Interaction.Interact();

                        if (interactableObject.CanInteractOnce)
                            interactableObject.ChangeStatus();
                    }
                }
                break;
            }
        }       
    }
}