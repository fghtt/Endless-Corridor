public abstract class EnemyState
{
    protected EnemyStateMachine _enemyStateMachine;

    public abstract void EnterIn();
    public abstract void Act();
    public abstract void Exit();
}