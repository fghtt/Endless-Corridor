using UnityEngine;

public class DistanceCondition : InteractionCondition
{
	[SerializeField]
	private float _distance;

    [SerializeField]
    private Transform _player;

    public override bool Check()
    {
        return
            Vector3.Distance(_player.position, transform.position) <= _distance;
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}