using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageSeconds;

    [SerializeField]
    private float _attackingDistance;

    private GameObject _player;
    private PlayerDeath _playerDeath;
    private CameraShaking _cameraShaking;

    private FlashlightPower _flashlightPower;

    private FieldOfView _fieldOfView;

    private RedScreenEffect _redScreenEffect;

    private Vector3 _lastPlayerPosition;
    public Vector3 LastPlayerPosition => _lastPlayerPosition;

    public bool CanSeePlayer => _fieldOfView.canSeePlayer;

    private bool _isAnimationEnded;
    public bool IsAnimationEnded => _isAnimationEnded;

    private void Start()
    {
        _fieldOfView = GetComponent<FieldOfView>();
        _playerDeath = _player.GetComponent<PlayerDeath>();
    }

    public void Initialize(FlashlightPower flashlightPower,
        GameObject player, RedScreenEffect redScreenEffect)
    {
        _flashlightPower = flashlightPower;
        _player = player;
        _cameraShaking = _player.GetComponentInChildren<CameraShaking>();
        _redScreenEffect = redScreenEffect;
    }

    public void ResetIsAnimationEnded()
    {
        _isAnimationEnded = false;
    }

    public void StartAttack()
    {
        _isAnimationEnded = false;
    }

    public void EndAttack()
    {
        float distance = Vector3.Distance(gameObject.transform.position,
            _player.transform.position);

        if (distance < _attackingDistance)
        {
            _isAnimationEnded = true;
            _cameraShaking.TriggerShake(0.2f, 0.08f);
            StartCoroutine("DamagePlayer");
            _redScreenEffect.Show();
        }

        _isAnimationEnded = true;
    }

    public void SetLastPlayerPosition(Vector3 position)
    {
        _lastPlayerPosition = position;
    }

    private IEnumerator DamagePlayer()
    {
        float passedTime = 0;

        while (passedTime < _damageSeconds)
        {
            if (!_flashlightPower.HasPower)
            {
                _playerDeath.Die();
                break;
            }

            float time = Time.deltaTime * 35;
            passedTime += time;
            _flashlightPower.DecreasePower(time);
            yield return null;
        }
    }
}