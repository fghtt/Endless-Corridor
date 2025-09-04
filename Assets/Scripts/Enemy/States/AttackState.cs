using UnityEngine;

public class AttackState : EnemyState
{
    private const string ATTACK_TRIGGER = "Attack";

    private float _rotationSpeed = 5f;
    private float _attackDistance = 1.7f;

    public AttackState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    public override void Act()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        Enemy enemy = enemyStates.Enemy;

        float distance = Vector3.Distance(enemy.gameObject.transform.position,
         enemy.Player.transform.position);

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

        if (distance > _attackDistance &&
            enemyStates.EnemyAttack.IsAnimationEnded)
        {
            enemyStates.EnemyAttack.ResetIsAnimationEnded();
            _enemyStateMachine.EnterIn<ChasingState>();
        }

        if (enemy.PlayerStates.CurrentState == PlayerStates.DEAD_STATE)
            _enemyStateMachine.EnterIn<PatrolState>();
    }

    public override void EnterIn()
    {
        _enemyStateMachine.
            EnemyStates.EnemyAnimations.SetTrigger(ATTACK_TRIGGER);
    }

    public override void Exit()
    {

    }
}