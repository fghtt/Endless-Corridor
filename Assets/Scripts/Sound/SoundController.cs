using UnityEngine;

public class SoundController : MonoBehaviour
{
	private bool _isNotPlaying = true;
	private AudioSource _audioSource;

    private void Start()
    {
		_audioSource = GetComponent<AudioSource>();
	}

    public void Play()
	{
		if (_isNotPlaying)
		{
            _isNotPlaying = false;
            _audioSource.Play();
        }
	}

	public void Stop()
	{
		_audioSource.Pause();
		_isNotPlaying = true;
	}
}