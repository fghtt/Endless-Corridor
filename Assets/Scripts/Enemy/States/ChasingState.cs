using UnityEngine;

public class ChasingState : EnemyState
{
    private const string RUNNING_TRIGGER = "Running";
    private float _rotationSpeed = 5f;

    private float _attackDistance = 2.5f;


    public ChasingState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    public override void Act()
    {
        _enemyStateMachine.EnemyStates.EnemyMovement.Run();
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        Enemy enemy = enemyStates.Enemy;

        enemyStates.EnemyMovement.MoveTo(enemy.Player.transform.position);

        Vector3 direction = enemy.Player.transform.position
            - enemy.transform.position;
        direction.y = 0f; 
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation
                = Quaternion.Slerp(enemy.transform.rotation, targetRotation,
                _rotationSpeed * Time.deltaTime);
        }

        if (!enemyStates.EnemyAttack.CanSeePlayer)
            _enemyStateMachine.EnterIn<HiringState>();

        float distance = Vector3.Distance(enemy.gameObject.transform.position,
            enemy.Player.transform.position);

        if (distance < _attackDistance)
            _enemyStateMachine.EnterIn<AttackState>();
    }

    public override void EnterIn()
    {
        _enemyStateMachine.EnemyStates
           .EnemyAnimations.SetTrigger(RUNNING_TRIGGER);
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        enemyStates.EnemyScream.Scream();
    }

    public override void Exit()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        Enemy enemy = enemyStates.Enemy;
        enemyStates.EnemyAttack
            .SetLastPlayerPosition(enemy.Player.transform.position);
    }
}