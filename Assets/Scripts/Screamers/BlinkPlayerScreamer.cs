using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkPlayerScreamer : Screamer
{
    private Image _image; 
    [SerializeField] private float _blinkDuration = 0.5f;
    [SerializeField] private int _blinkCount = 3;

    private bool _isPlaying;
    private AudioSource _audioSource;

    private void Start()
    {
        _image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void DoScreamer()
    {
        _image.gameObject.SetActive(true);
        StartCoroutine(Blink());
        _audioSource.Play();
}

    public override bool IsPlaying()
    {
        return _isPlaying;
    }

    private IEnumerator Blink()
    {
        _isPlaying = true;

        for (int i = 0; i < _blinkCount; i++)
        {
            yield return StartCoroutine(Fade(1, 0, _blinkDuration / 2));

            yield return StartCoroutine(Fade(0, 1, _blinkDuration / 2));
        }

        _isPlaying = false;
        _image.gameObject.SetActive(false);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;

        Color startColor = _image.color;
        startColor.a = startAlpha;
        _image.color = startColor;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);

            Color newColor = _image.color;
            newColor.a = alpha;
            _image.color = newColor; 

            yield return null;
        }

        Color finalColor = _image.color;
        finalColor.a = endAlpha;
        _image.color = finalColor;
    }
}