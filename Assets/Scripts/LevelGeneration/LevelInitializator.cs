using UnityEngine;

public class LevelInitializator : MonoBehaviour
{
    [SerializeField]
    private GameObject _flashlightInHand;

    [SerializeField]
    private GameObject _flashlightOnATable;

    [SerializeField]
    private ReadNoteInteraction _note; 

    [SerializeField]
    private PlayerStates _playerStates;

    [SerializeField]
    private PlayerAnimations _playerAnimations;

    [SerializeField]
    private PassedCorridorsCount _passedCorridorsCount;

    [SerializeField]
    private Journal _journal;

    private void Awake()
    {
        CrazyGames.CrazySDK.Game.GameplayStart();

        if (PlayerPrefs.HasKey(Saves.PLAYER_DATA_KEY))
        {
            string json = PlayerPrefs.GetString(Saves.PLAYER_DATA_KEY);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            _flashlightInHand.SetActive(true);
            _flashlightOnATable.SetActive(false);
            _flashlightOnATable.
                GetComponent<FlashlightPickingUpAction>().PerformAnAction();
            _note.InteractWithoutTextWindow();

            _playerStates.ChangeState(PlayerStates.IDLE_STATE);
            _passedCorridorsCount.SetCountValue(playerData._passedCorridorsCount);

            foreach (int noteId in playerData._collectedNotes)
                _journal.AddNote(noteId);
        } else
        {
            _playerAnimations.StartCutscene();
            _playerStates.ChangeState(PlayerStates.AWAKE_STATE);
        }
    }
}