using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

public class Subtitles : MonoBehaviour
{
    [SerializeField] private Language _language;

    private TextMeshProUGUI _textMeshPro;

    private bool _isShowing;

    [Inject]
    private void Construct(Language language)
    {
        _language = language;
    }

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void ShowText(int id)
    {
        if (!_isShowing)
        {
            gameObject.SetActive(true);
            ReplicasLocalizationData localizationData =
                (ReplicasLocalizationData)
                _language.GetInscription<ReplicasLocalizationType>(id);

            _textMeshPro.text = "";
            _isShowing = true;
            StartCoroutine(DisplayText(localizationData.Content));
        }
    }

    private IEnumerator DisplayText(string replica)
    {
        char[] chars = replica.ToCharArray();

        foreach (char singleChar in chars)
        {
            _textMeshPro.text += singleChar;
             yield return new WaitForSeconds(0.07f);
        }

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
        _isShowing = false;
    }
}