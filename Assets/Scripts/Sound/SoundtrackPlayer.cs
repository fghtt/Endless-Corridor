using UnityEngine;
using System.Collections.Generic;

public class SoundtrackPlayer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> _soundtracks;

    [SerializeField]
    private float _playingInterval;

    private float _passedTime;
    private int _lastUsedTrack;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            if (_passedTime < _playingInterval)
                _passedTime += Time.deltaTime;
            else
            {
                AudioClip audioClip = GetTrack();
                _audioSource.clip = audioClip;
                _passedTime = 0;
                _audioSource.Play();
            }
        }     
    }

    private AudioClip GetTrack()
    {
        int random = Random.Range(0, _soundtracks.Count);

        if (random == _lastUsedTrack)
            return GetTrack();

        _lastUsedTrack = random;
        return _soundtracks[random];
    }
}