    using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private UI _ui;

    [SerializeField]
    private DeathWindow _deathWindow;

    private PlayerController _playerController;
    private PlayerStates _playerStates;

    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _playerStates = GetComponentInParent<PlayerStates>();
    }

    public void EndCutscene()
    {
        _playerController.ContinueControlling();
        _playerStates.ChangeState(PlayerStates.IDLE_STATE);
        _ui.ShowUI();
    }

    public void StartCutscene()
    {
        _ui.HideUI();
        _playerController.StopControlling();
    }

    public void ShowDeathWindow()
    {
        _deathWindow.Show();
    }
}