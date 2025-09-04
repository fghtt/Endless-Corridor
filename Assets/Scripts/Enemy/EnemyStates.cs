using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine => _enemyStateMachine;

    private EnemyMovement _enemyMovement;
    public EnemyMovement EnemyMovement => _enemyMovement;

    private EnemyAttack _enemyAttack;
    public EnemyAttack EnemyAttack => _enemyAttack;

    private EnemyAnimations _enemyAnimations;
    public EnemyAnimations EnemyAnimations => _enemyAnimations;

    private EnemyScream _enemyScream;
    public EnemyScream EnemyScream => _enemyScream;

    private Enemy _enemy;
    public Enemy Enemy => _enemy;

    private void Start()
    {
        _enemyStateMachine = new EnemyStateMachine(this);
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
        _enemy = GetComponent<Enemy>();
        _enemyScream = GetComponentInChildren<EnemyScream>();
    }

    private void Update()
    {
        _enemyStateMachine.ActCurentState();
    }

    public void SetPatrolState()
    {
        _enemyStateMachine.EnterIn<PatrolState>();
    }
}