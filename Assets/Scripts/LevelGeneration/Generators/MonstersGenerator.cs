using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class MonstersGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _monster;
    [SerializeField] private int _minimalMonstersOnLevel;
    [SerializeField] private int _maximumMonstersOnLevel;

    [SerializeField]
    private int _corridorsBeforeMonsterSpawn;
    public int CorridorsBeforeMonsterSpawn => _corridorsBeforeMonsterSpawn;

    private CorridorsGenerator _corridorsGenerator;
    private RedScreenEffect _redScreenEffect;
    private FlashlightPower _flashlightPower;

    private List<Corridor> _createdCorridors
        => _corridorsGenerator.CreatedCorridors;

    private List<int> _corridorsWithMonsters = new List<int>();

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator,
        RedScreenEffect redScreenEffect, FlashlightPower flashlightPower)
    {
        _corridorsGenerator = corridorsGenerator;
        _redScreenEffect = redScreenEffect;
        _flashlightPower = flashlightPower;
    }

    public void Generate(GameObject player)
    {
        int monstersCount = Random.Range(_minimalMonstersOnLevel,
            _maximumMonstersOnLevel);

        for (int i = 0; i < monstersCount; i++)
        {
            int corridorIndex = GetCorridorWithoutMonster();
            Corridor corridor = _createdCorridors[corridorIndex];
            CreateMonster(corridor, _monster, corridorIndex, player);
        }
    }


    public void CreateMonster(Corridor corridor, GameObject monsterPrefab,
        int corridorIndex, GameObject player)
    {
        if (corridor.UsedMonstersSpawnsCount < corridor.MonsterSpawnsCount)
        {
            GameObject monster = Instantiate(monsterPrefab);
            monster.transform.position = corridor.DetermineSpawnPoint().position;
            Enemy enemy = monster.GetComponent<Enemy>();
            enemy.Initialize(corridor.PatrolPoints, player, _flashlightPower,
                _redScreenEffect, corridorIndex,  this);
            enemy.gameObject.transform.SetParent(corridor.transform);
            monster.SetActive(true);
        }
    }

    public bool HasAMonster(int corridorIndex)
    {
        return _corridorsWithMonsters.Contains(corridorIndex);
    }

    private int GetCorridorWithoutMonster()
    {
        int randomCorridor = Random.Range(0, _createdCorridors.Count);
        Corridor corridor = _createdCorridors[randomCorridor];

        if (_corridorsWithMonsters.Contains(randomCorridor)
            || corridor.MonsterSpawnsCount == 0)
            return GetCorridorWithoutMonster();

        return randomCorridor;
    }

    public void ClearCorridor(int corridorIndex)
    {
        _corridorsWithMonsters.Remove(corridorIndex);
    }
}