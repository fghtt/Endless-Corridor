using UnityEngine;
using Zenject;

public class Saves : MonoBehaviour
{
	private PlayerData _playerData;
    private Journal _journal;
    private PassedCorridorsCount _passedCorridorsCount;

    [SerializeField] private FlashlightPickingUpAction _flashlightPickingUpAction;
    [SerializeField] private PlayerRebirth _playerRebirth;

    public const string PLAYER_DATA_KEY = "playerData";

    [Inject]
    private void Construct(PassedCorridorsCount passedCorridorsCount,
        Journal journal)
    {
        _passedCorridorsCount = passedCorridorsCount;
        _journal = journal;
    }

    private void Awake()
    {
        _playerData = new PlayerData();
    }

    public void Save()
    {
        _playerData.Initialize(_passedCorridorsCount.GetPassedCordors(),
            _flashlightPickingUpAction.IsPickedUp,
            _journal.CollectedNotes);

        string json = JsonUtility.ToJson(_playerData, true); // true для форматирования JSON
        PlayerPrefs.SetString(PLAYER_DATA_KEY, json);
        PlayerPrefs.Save(); 
    }

    public PlayerData GetSaves()
    {
        string json = PlayerPrefs.GetString(PLAYER_DATA_KEY);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

        return playerData;
    }
}