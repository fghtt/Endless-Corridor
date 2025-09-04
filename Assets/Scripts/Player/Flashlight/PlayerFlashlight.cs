using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
	[SerializeField]
	private GameObject _light;

    [SerializeField]
	private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _audioClip;

    private float _volume = 1;

    private bool _isActivated;
    public bool IsActivated => _isActivated;

    public void TurnOn()
	{
        if (!_isActivated)
        {
            _audioSource.clip = _audioClip;
            _audioSource.volume = _volume;
            _audioSource.Play();
            _light.SetActive(true);
            _isActivated = true;
        }
    }

	public void TurnOff()
	{
        if (_isActivated)
        {
            _audioSource.clip = _audioClip;
            _audioSource.volume = _volume;
            _audioSource.Play();
            _light.SetActive(false);
            _isActivated = false;
        }
    }
}