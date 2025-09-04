using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canControlling = true;
    public bool CanControlling => _canControlling;

    private PlayerStates _playerStates;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void StopControlling()
    {
        _playerStates.ChangeState(PlayerStates.IDLE_STATE);
        _canControlling = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void ContinueControlling()
    {
        _canControlling = true;
    }
}