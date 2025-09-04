using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "Enemies/EnemyType")]
public class EnemyType : ScriptableObject
{
	[SerializeField]
	private float _timeToKill;
	public float TimeToKill => _timeToKill;

    [SerializeField]
    private float _costToKill;
    public float CostToKill => _costToKill;
}