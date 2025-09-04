using UnityEngine;
using System.Collections;

public class PlayerAttackSound : MonoBehaviour
{
	[SerializeField]
	private AudioClip _chargingSound;

	[SerializeField]
	private AudioClip _explodeSound;

	private AudioSource _audioSource;

	private float _passedTime;
	private Coroutine _passedTimeCoroutine;
	private bool _isPlaying;
	private bool _isReversing;

	private float _volume = 0.387f;

    private void Start()
    {
		_audioSource = GetComponent<AudioSource>();
    }

    public void Charge()
	{
		if (!_isPlaying)
		{
            _audioSource.clip = _chargingSound;
            _passedTime = 0;
			_audioSource.pitch = 1;
            _audioSource.volume = _volume;
            _audioSource.Play();
			_isPlaying = true;
			_isReversing = false;
			_passedTimeCoroutine = StartCoroutine("CountPassedTime");
        }
	}

	private IEnumerator CountPassedTime()
	{
		_passedTime += Time.deltaTime;

		while (_passedTime < _chargingSound.length)
			yield return null;
	}

	public void Reverse()
	{
		if (!_isReversing)
		{
            _audioSource.Stop();
            StopCoroutine(_passedTimeCoroutine);
            _audioSource.clip = _chargingSound;
            _audioSource.time = _passedTime;
            _audioSource.pitch = -1;
			_audioSource.volume = _volume;
			_audioSource.Play();
            _isPlaying = false;
            _isReversing = true;
        }
	}

	public void Explode()
	{
		_audioSource.Stop();
		_audioSource.clip = _explodeSound;
		_audioSource.volume = _volume;
		_audioSource.pitch = 1;
		_audioSource.Play();
		_isPlaying = false;
	}
}