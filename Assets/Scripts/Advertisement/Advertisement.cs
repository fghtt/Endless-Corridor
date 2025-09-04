using UnityEngine;
using Zenject;

public class Advertisement : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] float _showingInterval;

    private CreatingLevelWindow _creatingLevelWindow;

	private AdvertisementService _service;
    private float _passedTime;

    public bool CanShowAdvert => _passedTime >= _showingInterval;

    [Inject]
    private void Construct(CreatingLevelWindow creatingLevelWindow)
    {
        _creatingLevelWindow = creatingLevelWindow;
    }

    private void Start()
    {
        _service = new CrazyGamesAdvertisement();
    }

    private void Update()
    {
        if (_passedTime < _showingInterval)
            _passedTime += Time.deltaTime;
    }

    public void ShowMidgameAdvert()
    {
        _service.ShowMidgameAdvert(_audioSource);
    }

    public void ShowAdvertWhileCreatingLevel()
    {
        _service.ShowAdvertWhileCreatingLevel(_creatingLevelWindow);
        _passedTime = 0;
    }
}