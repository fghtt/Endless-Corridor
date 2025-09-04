using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PlayerController _playerController;
    private PlayerStates _playerStates;
    private SoundController _soundController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
        _playerStates = GetComponent<PlayerStates>();
        _soundController = GetComponent<SoundController>();
    }

    private void FixedUpdate()
    {
        if (_playerController.CanControlling)
        {
            float xDir = Input.GetAxis("Horizontal");
            float yDir = Input.GetAxis("Vertical");

            Vector3 velocityVector = transform.right * xDir + yDir *
                transform.forward;
            velocityVector *= _speed;

            _rigidbody.velocity = velocityVector;

            if (velocityVector.magnitude == 0)
            {
                _playerStates.ChangeState(PlayerStates.IDLE_STATE);
                _soundController.Stop();
            }
            else
            {             
                _playerStates.ChangeState(PlayerStates.WALKING_STATE);
                _soundController.Play();
            }
        }
    }
}