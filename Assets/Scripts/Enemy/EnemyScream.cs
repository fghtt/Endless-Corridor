using UnityEngine;
using System.Collections.Generic;

public class EnemyScream : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    [SerializeField] private float _minimalTime;
    [SerializeField] private float _maximalTime;

    private AudioSource _audioSource;
    private int _lastUsedScream;
    private float _passedTime;
    private float _targetTime;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _targetTime = Random.Range(_minimalTime, _maximalTime);
    }

    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            if (_passedTime <= _targetTime)
                _passedTime += Time.deltaTime;
            else
            {
                AudioClip audioClip = DetermineClip();
                _audioSource.clip = audioClip;
                _audioSource.Play();
                _passedTime = 0;
                _targetTime = Random.Range(_minimalTime, _maximalTime);
            }
        }       
    }

    private AudioClip DetermineClip()
    {
        int random = Random.Range(0, _audioClips.Count);

        if (random == _lastUsedScream)
            return DetermineClip();


        _lastUsedScream = random;
        return _audioClips[random];
    }

    public void Scream()
    {
        if (!_audioSource.isPlaying)
        {
            AudioClip audioClip = DetermineClip();
            _audioSource.clip = audioClip;
            _audioSource.Play();
            _passedTime = 0;
            _targetTime = Random.Range(_minimalTime, _maximalTime);
        }
    }
}