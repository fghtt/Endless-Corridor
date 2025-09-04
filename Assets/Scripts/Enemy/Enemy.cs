using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyType _enemyType;
    public EnemyType EnemyType => _enemyType;

    private EnemyStates _enemyStates;
    public EnemyStates EnemyStates => _enemyStates;

    private EnemyAttack _enemyAttack;

    private GameObject _player;
    public GameObject Player => _player;

    private PlayerStates _playerStates;
    public PlayerStates PlayerStates => _playerStates;

    private PlayerDeath _playerDeath;
    public PlayerDeath PlayerDeath => _playerDeath;

    private int _corridorIndex;
    public int CorridorIndex => _corridorIndex;

    private MonstersGenerator _monstersGenerator;
    public MonstersGenerator MonstersGenerator => _monstersGenerator;

    private EnemyMovement _enemyMovement;

    public void Initialize(List<Transform> patrolPoints, GameObject player,
        FlashlightPower flashlightPower, RedScreenEffect redScreen,
        int corridorIndex, MonstersGenerator monstersGenerator)
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyStates = GetComponent<EnemyStates>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _player = player;
        _enemyMovement.Initialize(patrolPoints);
        _enemyAttack.Initialize(flashlightPower, _player, redScreen);
        _playerStates = _player.GetComponent<PlayerStates>();
        _playerDeath = _player.GetComponent<PlayerDeath>();
        _corridorIndex = corridorIndex;
        _monstersGenerator = monstersGenerator;
    }
}