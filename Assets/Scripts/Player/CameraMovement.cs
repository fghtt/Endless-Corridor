using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField]
	private float _sensitivity;

    [SerializeField]
    private float _verticalLimit;

    private Transform _player;
    private float _verticalRotation;
    private PlayerController _playerController;
    private GameObject _container;

    private void Awake()
    {
        _player = transform.parent.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerController
            = transform.parent.parent.GetComponent<PlayerController>();
        _container = transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        if (_playerController.CanControlling)
        {
            MoveHorizontal();
            MoveVertical();
        }
    }

    private void MoveHorizontal()
    {
        float xDir = Input.GetAxis("Mouse X");

        _player.Rotate(Vector3.up, xDir * _sensitivity);
    }

    private void MoveVertical()
    {
        float direction = Input.GetAxis("Mouse Y");
        _verticalRotation -= direction * _sensitivity;
        _verticalRotation
            = Mathf.Clamp(_verticalRotation, -_verticalLimit, _verticalLimit);
        _container.transform.localRotation
            = Quaternion.Euler(_verticalRotation, 0, 0);
    }
}