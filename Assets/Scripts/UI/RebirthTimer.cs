using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Zenject;

public class RebirthTimer : MonoBehaviour
{
    private TextMeshProUGUI _timerText;
    private Inscription _inscription;
    private PassedCorridorsCount _passedCorridorsCount;

    [SerializeField]
    private PlayerRebirth _playerRebirth;

    [SerializeField]
    private float _respawnTime = 10f;

    private float _timeRemaining;

    [Inject]
    private void Construct(PassedCorridorsCount passedCorridorsCount)
    {
        _passedCorridorsCount = passedCorridorsCount;
    }

    void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
        _inscription = GetComponent<Inscription>();
        _timeRemaining = _respawnTime;
        UpdateTimerText();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _timeRemaining = _respawnTime;
    }

    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            HandleRespawn();
        }
    }

    private void UpdateTimerText()
    {
        if (_inscription.GetInscription() != null)
        {
            _timerText.text = string.Format(_inscription.GetInscription(),
                Mathf.CeilToInt(_timeRemaining));
        }
    }

    private void HandleRespawn()
    {
        _timeRemaining = 0;
        UpdateTimerText();

        PlayerPrefs.SetInt(PlayerData.PASSED_CORIDORS_COUNT_KEY,
            _passedCorridorsCount.GetPassedCordors());
        SceneManager.LoadScene(2);
    }
}
