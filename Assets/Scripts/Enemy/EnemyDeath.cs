using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField]
    private AfterKillingEffect _monsterDeathEffect;

    private float _damagingTime;
	public float DamagingTime => _damagingTime;

    private Enemy _enemy;
	public Enemy Enemy => _enemy;

    private float _timeAfterDamage;
	private float _resetTime = 0.2f;

	private void Start()
	{
		_enemy = GetComponent<Enemy>();
	}

    private void Update()
    {
		if (_damagingTime > 0)
		{
            _timeAfterDamage += Time.deltaTime;

			if (_timeAfterDamage > _resetTime)
				ResetDamage();
        }
    }

    public void Damage()
	{
		if (_damagingTime > _enemy.EnemyType.TimeToKill)
			Die();

		_damagingTime += Time.deltaTime;
		_timeAfterDamage = 0;
    }

	private void Die()
	{
		_enemy.MonstersGenerator.ClearCorridor(_enemy.CorridorIndex);
        CreateMonsterDeathEffect();
        Destroy(gameObject);
	}

	private void ResetDamage()
	{
        _damagingTime -= Time.deltaTime;
		_damagingTime = Mathf.Max(_damagingTime, 0);
    }

    private void CreateMonsterDeathEffect()
    {
        GameObject effect = Instantiate(_monsterDeathEffect.gameObject);
        effect.transform.position = transform.position;
    }
}