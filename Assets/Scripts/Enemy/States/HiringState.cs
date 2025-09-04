using UnityEngine;

public class HiringState : EnemyState
{
    private const string WALKING_TRIGGER = "Walking";

    public HiringState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    public override void Act()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        EnemyMovement enemyMovement = enemyStates.EnemyMovement;

        if (enemyStates.EnemyAttack.CanSeePlayer)
            _enemyStateMachine.EnterIn<ChasingState>();

        if (enemyMovement.NavMeshAgent.remainingDistance
             <= enemyMovement.NavMeshAgent.stoppingDistance)
            _enemyStateMachine.EnterIn<LookAroundState>();
    }

    public override void EnterIn()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        enemyStates.EnemyMovement
            .MoveTo(enemyStates.EnemyAttack.LastPlayerPosition);
        _enemyStateMachine.EnemyStates
        .EnemyAnimations.SetTrigger(WALKING_TRIGGER);
             _enemyStateMachine.EnemyStates.EnemyMovement.Walk();
    }

    public override void Exit()
    {
 
    }
}