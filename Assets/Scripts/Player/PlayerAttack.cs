using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance = 10;

    [SerializeField]
    private Slider _killingIndicator;

    [SerializeField]
    private Light _light;

    [SerializeField]
    private float _intensityIncreasingValue;

    [SerializeField]
    private float _angleIncreasingValue;

    [SerializeField]
    private Image _whiteScreen;

    [SerializeField]
    private float _whiteScreenfadeDuration;

    private FlashlightPower _playerFlashlightPower;

    private Camera _mainCamera;
    private const string ENEMY_TAG = "Enemy";
    private float _baseLightIntensity;
    private float _baseAngleRange;
    private float _whiteScreenOpacity;
    private PlayerAttackSound _playerAttackSound;

    private EnemyDeath _lastKillingEnemy;

    private void Start()
    {
        _mainCamera = Camera.main;
        _baseLightIntensity = _light.intensity;
        _baseAngleRange = _light.spotAngle;
        _playerAttackSound = GetComponent<PlayerAttackSound>();
        _playerFlashlightPower = GetComponent<FlashlightPower>();
    }

    private void Update()
    {
        RaycastHit hit = CastRaycast();

        if (hit.collider != null && hit.collider.tag == ENEMY_TAG
            && _playerFlashlightPower.HasPower)
        {
            if (_lastKillingEnemy == null)
            {
                _lastKillingEnemy
                    = hit.collider.gameObject.GetComponent<EnemyDeath>();
            }
            Type enemyState
                = _lastKillingEnemy.Enemy
                .EnemyStates.EnemyStateMachine.CurrentState.GetType();
            if (enemyState != typeof(PatrolState))
            {
                Debug.Log("Attack");
                _playerAttackSound.Charge();
                Attack();
            }
        }  else
        {
            if (_killingIndicator.value > 0)
            {
                if (_lastKillingEnemy != null)
                {
                    ShowOnSlider(_lastKillingEnemy.Enemy, _lastKillingEnemy);
                    ShowOnFlashlightIntensity
                        (_lastKillingEnemy.Enemy, _lastKillingEnemy);
                    ShowOnFlashlightAngle(_lastKillingEnemy.Enemy,
                        _lastKillingEnemy);
                    _playerAttackSound.Reverse();
                }

                else
                {
                    _killingIndicator.value = 0;
                    StartCoroutine("DecreaseIntensity");
                    StartCoroutine("DecreaseAngle");
                }
            }
            else
                if (_lastKillingEnemy != null)
                    _lastKillingEnemy = null;
        }
    }

    private void Attack()
    {
        _lastKillingEnemy.Damage();

        if (_lastKillingEnemy.DamagingTime >=
            _lastKillingEnemy.Enemy.EnemyType.TimeToKill)
        {
            _playerAttackSound.Explode();
            StartCoroutine("ShowWhiteScreen");
            _playerFlashlightPower.
                DecreasePower(_lastKillingEnemy.Enemy.EnemyType.CostToKill);
        }

        ShowOnSlider(_lastKillingEnemy.Enemy, _lastKillingEnemy);
        ShowOnFlashlightIntensity(_lastKillingEnemy.Enemy, _lastKillingEnemy);
        ShowOnFlashlightAngle(_lastKillingEnemy.Enemy, _lastKillingEnemy);
    }

    private void ShowOnSlider(Enemy enemy, EnemyDeath enemyDeath)
    {
        float timeToKill = enemy.EnemyType.TimeToKill;
        float passedTime = enemyDeath.DamagingTime;

        float currentPercent = passedTime / (timeToKill / 100);
        _killingIndicator.value = currentPercent;
    }

    private void ShowOnFlashlightIntensity(Enemy enemy, EnemyDeath enemyDeath)
    {
        float timeToKill = enemy.EnemyType.TimeToKill;
        float passedTime = enemyDeath.DamagingTime;

        float currentPercent = Mathf.Clamp01(passedTime / timeToKill); // Нормализуем значение от 0 до 1

        float intensityIncrease
            = _intensityIncreasingValue * Mathf.Pow(currentPercent, 8); // Увеличиваем скорость роста

        _light.intensity = _baseLightIntensity + intensityIncrease;
    }

    private void ShowOnFlashlightAngle(Enemy enemy, EnemyDeath enemyDeath)
    {
        float timeToKill = enemy.EnemyType.TimeToKill;
        float passedTime = enemyDeath.DamagingTime;

        float currentPercent = Mathf.Clamp01(passedTime / timeToKill);

        float rangeIncrease
            = _angleIncreasingValue * Mathf.Pow(currentPercent, 7);
        _light.spotAngle = _baseAngleRange + rangeIncrease;
    }

    private IEnumerator ShowWhiteScreen()
    {
        Color color = _whiteScreen.color;

        while (_whiteScreenOpacity < 1)
        {
            _whiteScreenOpacity += 0.1f;
            color.a = _whiteScreenOpacity;
            _whiteScreen.color = color;

            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("HideWhiteScreen");
    }

    private IEnumerator HideWhiteScreen()
    {
        Color color = _whiteScreen.color;
        float elapsedTime = 0f;

        while (elapsedTime < _whiteScreenfadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / _whiteScreenfadeDuration);

            float opacity = Mathf.Lerp(1f, 0f, Mathf.Pow(t, 3));
            color.a = opacity;
            _whiteScreen.color = color;

            yield return null;
        }

        color.a = 0f;
        _whiteScreen.color = color;
    }

    private IEnumerator DecreaseIntensity()
    {
        if (_lastKillingEnemy == null)
        {
            while (_light.intensity > _baseLightIntensity)
            {
                _light.intensity -= 0.08f;

                yield return new WaitForSeconds(0.01f);
            }

            _light.intensity = _baseLightIntensity;
        }
    }

    private IEnumerator DecreaseAngle()
    {
        if (_lastKillingEnemy == null)
        {
            while (_light.spotAngle > _baseAngleRange)
            {
                _light.spotAngle -= 1f;

                yield return new WaitForSeconds(0.001f);
            }

            _light.spotAngle = _baseAngleRange;
        }
    }

    private RaycastHit CastRaycast()
    {
        RaycastHit hit;
        Physics.Raycast(_mainCamera.transform.position,
            _mainCamera.transform.forward, out hit, _maxDistance,
            ~LayerMask.GetMask("Event", "PostProcessing"));

        return hit;
    }
}