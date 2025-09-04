using UnityEngine;
using System.Collections;

public class BlinkFlashlightScreamer : Screamer
{
    [SerializeField] private float _blinkDuration;
    [SerializeField] private int _blinkCount;
    [SerializeField] private float _maximalIntensity;
    [SerializeField] private float _minimalIntensity;

    private Light _light;
    private bool _isPlaying;
    private AudioSource _audioSource;

    private void Start()
    {
        _light = GetComponent<Light>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void DoScreamer()
    {
        StartCoroutine(Flick());
        _audioSource.Play();
    }

    public override bool IsPlaying()
    {
        return _isPlaying;
    }

    private IEnumerator Flick()
    {
        for (int i = 0; i < _blinkCount; i++)
        {
            yield return StartCoroutine(FadeLight(_maximalIntensity,
                _minimalIntensity, _blinkDuration));
            yield return StartCoroutine(FadeLight(_minimalIntensity,
                _maximalIntensity, _blinkDuration));
        }

        StartCoroutine(FadeLight(_light.intensity,
                _maximalIntensity, _blinkDuration));
    }

    private IEnumerator FadeLight(float startIntensity, float endIntensity,
        float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _light.intensity = Mathf.Lerp(startIntensity, endIntensity,
                elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        _light.intensity = endIntensity;
    }
}
