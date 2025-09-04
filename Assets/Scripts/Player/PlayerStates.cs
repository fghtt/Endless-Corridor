using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public const int IDLE_STATE = 0;
    public const int WALKING_STATE = 1;
    public const int DEAD_STATE = 2;
    public const int AWAKE_STATE = 3;

    private int _currentState;
    public int CurrentState => _currentState;

    [SerializeField]
    private Animator _cameraAnimator;
    public Animator CameraAnimator => _cameraAnimator;

    [SerializeField]
    private Animator _flashlightAnimator;

    [SerializeField]
    private Animator _lightAnimator;

    public void ChangeState(int state)
    {
        if (state != _currentState)
        {
            _currentState = state;
            _cameraAnimator.SetInteger("State", state);
            if (_flashlightAnimator.gameObject.activeSelf)
            {
                _flashlightAnimator.SetInteger("State", state);
                _lightAnimator.SetInteger("State", state);
            }
        }
    }
}