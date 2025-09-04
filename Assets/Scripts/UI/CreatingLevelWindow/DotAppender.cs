using UnityEngine;
using TMPro;
using System.Collections;
using Zenject;

public class DotAppender : MonoBehaviour
{
    [SerializeField] private int _dotCount = 0;
    [SerializeField] private Advertisement _advertisement;
    [SerializeField] private float _delay = 0.3f;

    private TextMeshProUGUI _displayText;  
    private int _appednedDots;
    private string _baseText;
    private Language _langugage;

    [Inject]
    private void Construct(Language language)
    {
        _langugage = language;
    }

    private void Start()
    {
        _displayText = GetComponent<TextMeshProUGUI>();
        InterfaceLocalizationData baseText
             = (InterfaceLocalizationData)_langugage
                 .GetInscription<InterfaceLocalizationType>(4);
        _baseText = baseText.Content;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        StartCoroutine(AppendDots());
    }

    private IEnumerator AppendDots()
    {
        _displayText.text = _baseText;

        while (_appednedDots < _dotCount)
        {
            _appednedDots++;
            _displayText.text = _baseText + new string('.', _appednedDots);

            yield return new WaitForSeconds(_delay);
        }

        _advertisement.ShowAdvertWhileCreatingLevel();
        _appednedDots = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}