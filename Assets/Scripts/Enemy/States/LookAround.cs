using UnityEngine;

public class LookAroundState : EnemyState
{
    private const string LOOK_AROUND_TRIGGER = "LookAround";

    public LookAroundState(EnemyStateMachine enemyStateMachine)
    {
        _enemyStateMachine = enemyStateMachine;
    }

    public override void Act()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        if (enemyStates.EnemyAttack.CanSeePlayer)
            _enemyStateMachine.EnterIn<ChasingState>();
    }

    public override void EnterIn()
    {
        EnemyStates enemyStates = _enemyStateMachine.EnemyStates;
        enemyStates.EnemyAnimations.SetTrigger(LOOK_AROUND_TRIGGER);
    }

    public override void Exit()
    {

    }
}