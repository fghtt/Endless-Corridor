using System;
using UnityEngine;
using Zenject;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
	public event Action OnGenerationStarted;

	[SerializeField] private GameObject _player;

    private CorridorsGenerator _corridorsGenerator;
	private RoomsGenerator _roomsGenerator;
	private MonstersGenerator _monstersGenerator;
	private PassedCorridorsCount _passedCorridorsCount;
	private BatteriesGenerator _batteriesGenerator;
	private NotesGenerator _notesGenerator;
	private Language _language;
	private Journal _journal;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator,
		RoomsGenerator roomsGenerator,
		MonstersGenerator monstersGenerator,
		PassedCorridorsCount passedCorridorsCount,
		BatteriesGenerator batteriesGenerator, NotesGenerator notesGenerator,
		Language language,
		Journal journal)
    {
		_corridorsGenerator = corridorsGenerator;
		_roomsGenerator = roomsGenerator;
		_monstersGenerator = monstersGenerator;
		_passedCorridorsCount = passedCorridorsCount;
		_batteriesGenerator = batteriesGenerator;
		_notesGenerator = notesGenerator;
		_language = language;
		_journal = journal;
    }

    private void Start()
	{
        GenerateLevel();
	}

	public void GenerateLevel()
	{
		StartCoroutine("GenerateLevelCoroutine");
		GenerateLevelCoroutine();
		OnGenerationStarted?.Invoke();
    }

	private IEnumerator GenerateLevelCoroutine()
	{
        _corridorsGenerator.Generate();

		int index = 0;

		foreach (Corridor corridor in _corridorsGenerator.CreatedCorridors)
		{
			_roomsGenerator.Generate(_player, index, corridor);

            if (_roomsGenerator.CreatedRooms.ContainsKey(index))
				_batteriesGenerator.Generate(_player, index, corridor);

			index++;
		}

		if (_passedCorridorsCount.CountValue >
			_monstersGenerator.CorridorsBeforeMonsterSpawn)
			_monstersGenerator.Generate(_player);

		int notesCount =
			_language.GetInscriptionsCount<InscriptionLocalizationType>();

		if (notesCount > _journal.CollectedNotes.Count + 1)
			_notesGenerator.Generate(_player);

		yield return null;
	}
}