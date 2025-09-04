using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Saves _saves;

    private PlayerStates _playerStates;
    private PlayerController _playerController;
    private CapsuleCollider _capsuleCollider;

    private bool _isDead;
    public bool IsDead => _isDead;

    private void Start()
    {
        _playerStates = GetComponent<PlayerStates>();
        _playerController = GetComponent<PlayerController>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void PlayDeathAnimation()
    {
        _playerController.StopControlling();
        _playerStates.ChangeState(PlayerStates.DEAD_STATE);
    }

    public void Die()
    {
        _capsuleCollider.enabled = false;
        _isDead = true;
        PlayDeathAnimation();
        _saves.Save();
    }
}