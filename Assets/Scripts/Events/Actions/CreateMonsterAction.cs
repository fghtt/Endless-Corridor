using UnityEngine;
using Zenject;

public class CreateMonsterAction : CustomAction.Action
{
    [SerializeField] int _spawnChance;

	private CorridorsGenerator _corridorsGenerator;
    private int _corridorIndex;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator)
    {
        _corridorsGenerator = corridorsGenerator;
    }

    public void Initialize(int corridorIndex)
    {
        _corridorIndex = corridorIndex;
    }

    public override void DoAction()
    {
        int random = Random.Range(0, 100);

        if (random <= _spawnChance)
        {
           // if (!_corridorsGenerator.HasAMonster(_corridorIndex))
               // _corridorsGenerator.SpawnMonster(_corridorIndex);
        }
    }
}