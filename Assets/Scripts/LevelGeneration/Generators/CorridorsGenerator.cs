using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Zenject;

public class CorridorsGenerator : MonoBehaviour
{
    [SerializeField]
    private int _amountOfCorridors;
    public int AmountOfCorridors => _amountOfCorridors;

    [SerializeField] private GameObject _batteryPrefab;
    [SerializeField] private GameObject _notePrefab;
    [SerializeField] private GameObject _exit;
    [SerializeField] private AudioSource _handAudioSource;
    
    [SerializeField] private List<GameObject> _corridors;

    private List<Corridor> _createdCorridors = new List<Corridor>();
    public List<Corridor> CreatedCorridors => _createdCorridors;

    private List<GameObject> _createdCorridorsObjects = new List<GameObject>();
    public List<GameObject> CreatedCorridorsObjects => _createdCorridorsObjects;

    private List<int> _lastCreatedCorridors = new List<int>();

    private PassedCorridorsCount _passedCorridorsCount;   
    private TextWindow _textWindow;
    private AmountOfBatteriesUI _amountOfBatteriesUI;
    private GameObject _player;
    private FlashlightPower _flashlightPower;
    private Journal _journal;
    private StartRoom _startRoom;

    [Inject]
    private void Consturct(PassedCorridorsCount passedCorridorsCount,
        TextWindow textWindow, AmountOfBatteriesUI amountOfBatteriesUI,
        PlayerStates playerStates, FlashlightPower flashlightPower,
        Journal journal, StartRoom startRoom)
    {
        _passedCorridorsCount = passedCorridorsCount;
        _player = playerStates.gameObject;
        _textWindow = textWindow;
        _amountOfBatteriesUI = amountOfBatteriesUI;
        _flashlightPower = flashlightPower;
        _journal = journal;
        _startRoom = startRoom;
    }

    public List<GameObject> Generate()
    {
        _lastCreatedCorridors = new List<int>();
        _createdCorridorsObjects = new List<GameObject>();
        _createdCorridors = new List<Corridor>();

        for (int i = 0; i < _amountOfCorridors; i++)
        {
            GenerateCorridor();
        }

        _createdCorridors.First().CreateNavigation();
        return _createdCorridorsObjects;
    }

    private GameObject DetermineCorridor()
    {
        int lastIndex = _corridors.Count - 1;
        int randomIndex = Random.Range(0, lastIndex + 1);

        foreach (int index in _lastCreatedCorridors)
            if (randomIndex == index)
                return DetermineCorridor();

        _lastCreatedCorridors.Add(randomIndex);
        return _corridors[randomIndex];
    }

    private void GenerateCorridor()
    {
        GameObject corridorPrefab = DetermineCorridor();
        GameObject createdCorridor = Instantiate(corridorPrefab);
        Corridor corridor = createdCorridor.GetComponent<Corridor>();
        corridor.Initialize(_passedCorridorsCount, _player, _batteryPrefab,
            _handAudioSource, _amountOfBatteriesUI, _flashlightPower,
            _notePrefab, _journal, _textWindow);    

        if (_createdCorridors.Count == 0)
            createdCorridor.transform.position
                = _startRoom.CreatedExit.CorridorPoint.position;
        else
        {
            Corridor lastCreatedCorridor = _createdCorridors.Last();
            createdCorridor.transform.position =
                lastCreatedCorridor.CreatedExit.CorridorPoint.position;
        }

        if (_createdCorridors.Count < _amountOfCorridors - 1)
            corridor.CreateExit(_exit, _player);

        _createdCorridors.Add(corridor);
        _createdCorridorsObjects.Add(createdCorridor);
    }
}