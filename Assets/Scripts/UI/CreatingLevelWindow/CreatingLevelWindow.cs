using UnityEngine;
using Zenject;

public class CreatingLevelWindow : MonoBehaviour
{
	[SerializeField] private PlayerController _playerController;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private DotAppender _dotAppender;

	private LevelGenerator _levelGenerator;
	private Advertisement _advertisement;

	[Inject]
	private void Construct(LevelGenerator levelGenerator,
		Advertisement advertisement)
	{
		_levelGenerator = levelGenerator;
		_advertisement = advertisement;
	}

    private void Start()
    {
		_levelGenerator.OnGenerationStarted += Show;
    }

    public void Show()
	{
		if (_advertisement.CanShowAdvert)
		{
            _audioSource.enabled = false;
            _playerController.StopControlling();
            _dotAppender.Show();
        }
	}

	public void Hide()
	{
		_audioSource.enabled = true;
		_playerController.ContinueControlling();
		_dotAppender.Hide();
	}
}