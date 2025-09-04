using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

	[SerializeField]
	private float _runningMultiplier;

    private List<Transform> _patrolPoints = new List<Transform>();
	private int _lastUsedPatrolPoint;

	private NavMeshAgent _navMeshAgent;
	public NavMeshAgent NavMeshAgent => _navMeshAgent;

	private float _changingDestinationDelay = 0.2f;
	private float _passedTimeDelay;
	private float _runningSpeed;

    private void Start()
    {
		_navMeshAgent = GetComponent<NavMeshAgent>();
		_navMeshAgent.speed = _speed;
		_runningSpeed = _speed * _runningMultiplier;
    }

    private void Update()
    {
		if (_passedTimeDelay > 0)
			_passedTimeDelay -= Time.deltaTime;
    }

	public void MoveTo(Vector3 position)
	{
		if (_passedTimeDelay <= 0)
		{
            _navMeshAgent.destination = position;
			_passedTimeDelay = _changingDestinationDelay;
        }	
	}

    public void Initialize(List<Transform> patrolPoints)
	{
		_patrolPoints = patrolPoints;
	}

	public void Patrol()
	{
        if (_passedTimeDelay <= 0)
        {
            Transform patrolPoint = DeterminePatrolPoint();
			_navMeshAgent.destination = patrolPoint.transform.position;
        }
    }

	public Transform DeterminePatrolPoint()
	{
        int randomPointIndex = Random.Range(0, _patrolPoints.Count);

		if (randomPointIndex == _lastUsedPatrolPoint)
			return DeterminePatrolPoint();

		_lastUsedPatrolPoint = randomPointIndex;
		return _patrolPoints[randomPointIndex];
    }

	public void Stop()
	{
		_navMeshAgent.speed = 0;
	}

	public void Continue()
	{
		_navMeshAgent.speed = _speed;
	}

	public void Run()
	{
		_navMeshAgent.speed = _runningSpeed;
	}

	public void Walk()
	{
		Continue();
	}
}