using UnityEngine;
using System.Collections.Generic;

public class ScreamersController : MonoBehaviour
{
	[SerializeField] private List<Screamer> _screamers;
	[SerializeField] private float _minimalScreamerInterval;
    [SerializeField] private float _maximumScreamerInterval;

	private float _passedTime;
	private float _targetTime;
    private int _lastUsedScreamer = 1;
    private Screamer _currentScreamer;

    private void Start()
    {
        _targetTime = DetermineScreamerTime();
    }

    private void Update()
    {
        if (_currentScreamer == null || !_currentScreamer.IsPlaying())
        {
            if (_passedTime < _targetTime)
                _passedTime += Time.deltaTime;
            else
            {
                Screamer screamer = DetermineScreamer();
                _currentScreamer = screamer;
                screamer.DoScreamer();
                _passedTime = 0;
            }
        }    
    }

    private Screamer DetermineScreamer()
    {
        int random = Random.Range(0, _screamers.Count);

        if (random == _lastUsedScreamer)
            return DetermineScreamer();

        _lastUsedScreamer = random;

        return _screamers[random];
    }

    private float DetermineScreamerTime()
    {
        float randomTime = Random.Range(_minimalScreamerInterval,
            _maximumScreamerInterval);

        return randomTime;
    }
}