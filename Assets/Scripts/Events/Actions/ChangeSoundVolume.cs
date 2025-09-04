using UnityEngine;
using System.Collections;

public class ChangeSoundVolume : CustomAction.Action
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _duration;
    [SerializeField] private float _targetVolume;

    public override void DoAction()
    {
        if (_audioSource.volume != _targetVolume)
            StartCoroutine(FadeOutAudio());
    }

    private IEnumerator FadeOutAudio()
    {
        float startVolume = _audioSource.volume; 
        float time = 0f;

        while (time < _duration)
        {
            time += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, _targetVolume, time / _duration);
            yield return null; 
        }

        _audioSource.volume = _targetVolume;
    }
}