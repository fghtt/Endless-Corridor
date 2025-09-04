using UnityEngine;
using System.Linq;
using Zenject;

public class NotesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _note;
    [SerializeField] private AudioSource _handAudioSource;

    private CorridorsGenerator _corridorsGenerator;
    private RoomsGenerator _roomsGenerator;
    private TextWindow _textWindow;
    private Journal _journal;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator,
        RoomsGenerator roomsGenerator, TextWindow textWindow, Journal journal)
    {
        _corridorsGenerator = corridorsGenerator;
        _roomsGenerator = roomsGenerator;
        _textWindow = textWindow;
        _journal = journal;
    }

    public void Generate(GameObject player)
    {
        if (_roomsGenerator.CreatedRooms.Count > 0)
        {
            int corridorIndex = Random.Range(0,
            _corridorsGenerator.CreatedCorridors.Count);

            if (_roomsGenerator.CreatedRooms.ContainsKey(corridorIndex))
                GenerateNote(corridorIndex, player);
            else
                Generate(player);
        }
    }

    private void GenerateNote(int corridorIndex, GameObject player)
    {
        int randomRoomIndex = Random.Range(0,
            _roomsGenerator.CreatedRooms[corridorIndex].Count);
        Room room = _roomsGenerator.CreatedRooms[corridorIndex][randomRoomIndex];

        int randomNoteSpawn = Random.Range(0, room.NoteSpawns.Count);
        GameObject createdNote = Instantiate(_note);

        createdNote.transform.position
            = room.NoteSpawns[randomNoteSpawn].position;
        createdNote.transform.rotation
            = room.NoteSpawns[randomNoteSpawn].rotation;
        createdNote.GetComponentInChildren<DistanceCondition>()
            .SetPlayer(player.transform);
        createdNote.transform.SetParent(room.gameObject.transform);

        int noteId;

        if (_journal.CollectedNotes.Count > 0)
            noteId = _journal.CollectedNotes.Last() + 1;
        else
            noteId = 3;

        createdNote.GetComponentInChildren<ReadNoteInteraction>()
            .Initialize(noteId, _textWindow, _handAudioSource, _journal);
    }
}