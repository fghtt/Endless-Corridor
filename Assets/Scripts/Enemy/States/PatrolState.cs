using UnityEngine;

public class PatrolState : EnemyState
{
    private const string WALKING_TRIGGER = "Walking";
    private float _rotationSpeed = 5f;
    private float _detectionDistance = 7f;

    public PatrolState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    public override void EnterIn()
    {
        EnemyMovement enemyMovement
            = _enemyStateMachine.EnemyStates.EnemyMovement;
        enemyMovement.Patrol();
        _enemyStateMachine.EnemyStates
            .EnemyAnimations.SetTrigger(WALKING_TRIGGER);
        _enemyStateMachine.EnemyStates.EnemyMovement.Walk();
    }

    public override void Act()
    {
        EnemyMovement enemyMovement
            = _enemyStateMachine.EnemyStates.EnemyMovement;
        EnemyAttack enemyAttack = _enemyStateMachine.EnemyStates.EnemyAttack;

        if (enemyMovement.NavMeshAgent.remainingDistance
            <= enemyMovement.NavMeshAgent.stoppingDistance)
            enemyMovement.Patrol();

        PlayerDeath playerDeath
            = _enemyStateMachine.EnemyStates.Enemy.PlayerDeath;
        if (enemyAttack.CanSeePlayer && !playerDeath.IsDead)
            _enemyStateMachine.EnterIn<ChasingState>();

        GameObject enemy = _enemyStateMachine.EnemyStates.Enemy.gameObject;
        GameObject player = _enemyStateMachine.EnemyStates.Enemy.Player;
        Vector3 direction = (player.transform.position -
            enemy.transform.position).normalized;

        RaycastHit hit;
        Physics.Raycast(enemy.transform.position, direction,
            out hit, _detectionDistance,  
            ~LayerMask.GetMask("Event", "PostProcessing", "Enemy"));

        if (Vector3.Distance(player.transform.position,
            enemy.transform.position) < _detectionDistance
            && hit.collider != null && hit.collider.CompareTag("Player"))
            LookAt(player, enemy);
    }

    public override void Exit()
    {
        
    }

    private void LookAt(GameObject player, GameObject enemy)
    {
        Vector3 direction = player.transform.position
           - enemy.transform.position;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation
                = Quaternion.Slerp(enemy.transform.rotation, targetRotation,
                _rotationSpeed * Time.deltaTime);
        }
    }
}