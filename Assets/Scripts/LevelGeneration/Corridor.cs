using UnityEngine;
using System.Collections.Generic;

public class Corridor : MonoBehaviour
{
	[SerializeField]
	private List<RoomPoint> _roomPoints;
	public List<RoomPoint> RoomPoints => _roomPoints;

	IncreasePassedCorridorsCountAction _increasePassedCorridorsCount;

    [SerializeField]
	private Transform _exitPoint;
	public Transform ExitPoint => _exitPoint;

    [SerializeField]
    private Transform _enterPoint;
    public Transform EnterPoint => _enterPoint;

	[SerializeField]
	private List<Transform> _monsterSpawns = new List<Transform>();
    public int MonsterSpawnsCount => _monsterSpawns.Count;

    private List<int> _usedMonsterSpawns = new List<int>();
	public int UsedMonstersSpawnsCount => _usedMonsterSpawns.Count;

	[SerializeField]
	private List<Transform> _patrolPoints = new List<Transform>();
	public List<Transform> PatrolPoints => _patrolPoints;
    public int PatrolPointsCount => _patrolPoints.Count;

	[SerializeField]
	private int _minBatteries;
	public int MinBatteries => _minBatteries;

	[SerializeField]
	private int _maxBatteries;
	public int MaxBatteries => _maxBatteries;

	private GameObject _battery;

    private Unity.AI.Navigation.NavMeshSurface _navMeshSurface;

    private List<int> _createdRoomsIndexes = new List<int>();
	private int _creatingRoomIndex;

	private List<Room> _createdRooms = new List<Room>();
	public List<Room> CreatedRooms => _createdRooms;

	private Exit _createdExit;
	public Exit CreatedExit => _createdExit;

	private GameObject _player;
	private AudioSource _handAudioSource;
	private AmountOfBatteriesUI _amountOfBatteries;
	private FlashlightPower _flashlightPower;
	private GameObject _note;
	private Journal _journal;
	private TextWindow _textWindow;

    private void Awake()
    {
		_createdRoomsIndexes = new List<int>();
		_increasePassedCorridorsCount
			= GetComponentInChildren<IncreasePassedCorridorsCountAction>();
        _navMeshSurface = GetComponentInChildren<Unity.AI.Navigation.NavMeshSurface>();
	}

	public void Initialize(PassedCorridorsCount passedCorridorsCount,
		GameObject player, GameObject battery, AudioSource handAudioSource,
		AmountOfBatteriesUI amountOfBatteries, FlashlightPower flashlightPower,
		GameObject note, Journal journal, TextWindow textWindow)
	{
        _increasePassedCorridorsCount.SetPassedCorridorsCount(passedCorridorsCount);
		_player = player;
		_battery = battery;
		_handAudioSource = handAudioSource;
		_amountOfBatteries = amountOfBatteries;
		_flashlightPower = flashlightPower;
		_note = note;
		_journal = journal;
		_textWindow = textWindow;
	}

	public void CreateExit(GameObject exit, GameObject player)
	{
		GameObject createdExit = Instantiate(exit);
		createdExit.transform.position = _exitPoint.position;
		_createdExit = createdExit.GetComponent<Exit>();
		_createdExit.InitializeExit(player);
		createdExit.transform.SetParent(gameObject.transform);
	}

	private GameObject DetermineRoom(List<GameObject> rooms)
	{
		int amountOfRooms = rooms.Count;

        _creatingRoomIndex = Random.Range(0, amountOfRooms);

		foreach (int roomIndex in _createdRoomsIndexes)
		{
			if (_creatingRoomIndex == roomIndex)
				return DetermineRoom(rooms);
		}

		_createdRoomsIndexes.Add(_creatingRoomIndex);
		return rooms[_creatingRoomIndex];
	}

	public void ClearNavMesh()
	{
		_navMeshSurface.RemoveData();
	}

	public void CreateNavigation()
	{
        _navMeshSurface.BuildNavMesh();
    }

	public Transform DetermineSpawnPoint()
	{
		int spawnsCount = _monsterSpawns.Count;
		int randomSpawnIndex = Random.Range(0, spawnsCount);

		foreach (int spawn in _usedMonsterSpawns)
		{
			if (spawn == randomSpawnIndex)
				return DetermineSpawnPoint();
		}

		_usedMonsterSpawns.Add(randomSpawnIndex);
		return _monsterSpawns[randomSpawnIndex];
	}
}