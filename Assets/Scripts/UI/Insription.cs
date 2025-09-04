using TMPro;
using UnityEngine;
using Zenject;

public class Inscription : MonoBehaviour
{
    [SerializeField]
    private int _id;

	private Language _language;

    private TextMeshProUGUI _tmpro;
    private string _inscription;

    [Inject]
    private void Construct(Language language)
    {
        _language = language;
    }

    private void Start()
    {
        _tmpro = GetComponent<TextMeshProUGUI>();

        InterfaceLocalizationData inscription
         = (InterfaceLocalizationData)_language
          .GetInscription<InterfaceLocalizationType>(_id);

        if (inscription != null)
        {
            _inscription = inscription.Content;
            _tmpro.text = _inscription;
        }
    }

    public string GetInscription()
    {
        return _inscription;
    }
}