using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class DeathWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private float targetFontSize = 36f;
    [SerializeField] private float targetAlpha = 1f;
    [SerializeField] private float _textDuration = 2f;
    [SerializeField] private Image _background;
    [SerializeField] private float _backgroundDuration;
    [SerializeField] private RebirthTimer _rebirthTimer;
    [SerializeField] private Advertisement _advertisement;


    public void Show()
    {
        gameObject.SetActive(true);
        ShowBackground();
    }

    private IEnumerator AnimateTextCoroutine()
    {
        float startFontSize = textMeshPro.fontSize;
        float startAlpha = textMeshPro.color.a;

        float elapsedTime = 0f;

        while (elapsedTime < _textDuration)
        {
            float t = elapsedTime / _textDuration;

            textMeshPro.fontSize = Mathf.Lerp(startFontSize, targetFontSize, t);

            Color color = textMeshPro.color;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            textMeshPro.color = color;

            elapsedTime += Time.deltaTime;
            yield return null; 
        }
        textMeshPro.fontSize = targetFontSize;
        Color finalColor = textMeshPro.color;
        finalColor.a = targetAlpha;
        textMeshPro.color = finalColor;
    }

    public void ShowBackground()
    {
        StartCoroutine(FadeInCoroutine(targetAlpha));
    }

    private IEnumerator FadeInCoroutine(float targetAlpha)
    {
        Color color = _background.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < _backgroundDuration)
        {
            float t = elapsedTime / _backgroundDuration;

            color.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            _background.color = color;

            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        color.a = targetAlpha;
        _background.color = color;
        //_advertisement.ShowMidgameAdvert();
        StartCoroutine(AnimateTextCoroutine());
        _rebirthTimer.Show();
    }
}