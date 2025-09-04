using System;
using System.Collections.Generic;

public class EnemyStateMachine
{
    private EnemyStates _enemyStates;
    public EnemyStates EnemyStates => _enemyStates;

    private EnemyState _currentState;
    public EnemyState CurrentState => _currentState;

    private Dictionary<Type, EnemyState> _states
        = new Dictionary<Type, EnemyState>();

    public EnemyStateMachine(EnemyStates enemyStates)
    {
        _enemyStates = enemyStates;
        _states.Add(typeof(PatrolState), new PatrolState(this));
        _states.Add(typeof(ChasingState), new ChasingState(this));
        _states.Add(typeof(HiringState), new HiringState(this));
        _states.Add(typeof(LookAroundState), new LookAroundState(this));
        _states.Add(typeof(AttackState), new AttackState(this));
        _currentState = _states[typeof(PatrolState)];
    }

    public void EnterIn<T>() where T : EnemyState
    {
        EnemyState state = _states[typeof(T)];
        _currentState.Exit();
        state.EnterIn();
        _currentState = state;  
    }

    public void ActCurentState()
    {
        _currentState.Act();
    }
}