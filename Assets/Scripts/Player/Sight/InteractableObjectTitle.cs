using UnityEngine;
using Zenject;

public class InteractableObjectTitle : MonoBehaviour
{
    [SerializeField]
    private int _titleId;

    private string _title;

    private Language _language;

    [Inject]
    private void Construct(Language language)
    {
        _language = language;
    }

    public string FindTitle()
    {
        if (_title == null)
        {
            InteractableObjectsLocalizationData localizationData =
            (InteractableObjectsLocalizationData)
            _language.GetInscription<InteractableObjectsLocalizationType>
            (_titleId);
            _title = localizationData.Content;
        }

        return _title;
    }
}