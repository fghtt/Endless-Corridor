using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawns;

    [SerializeField] private List<Transform> _batteriesSpawns = new List<Transform>();

    [SerializeField]
    private List<Transform> _noteSpawns = new List<Transform>();
    public List<Transform> NoteSpawns => _noteSpawns;   

    [SerializeField]
    private CreateMonsterAction _createMonsterAction;
    public CreateMonsterAction CreateMonsterAction => _createMonsterAction;

    private bool _hasBattery;
    public bool HasBattery => _hasBattery;

    public void SpawnBattery(GameObject battery, GameObject player,
        AudioSource handAudioSource, AmountOfBatteriesUI amountOfBatteries)
    {
        int random = Random.Range(0, _batteriesSpawns.Count);
        GameObject createdBattery = Instantiate(battery);
        createdBattery.transform.position = _batteriesSpawns[random].position;
        _hasBattery = true;
        createdBattery.GetComponentInChildren<DistanceCondition>()
            .SetPlayer(player.transform);
        createdBattery.transform.SetParent(gameObject.transform);
        createdBattery.GetComponentInChildren<BatteryPickingUpAction>()
            .Initialize(amountOfBatteries, handAudioSource);
    }

    public void SpawnNote(GameObject note, GameObject player,
        AudioSource handAudioSource, Journal journal, TextWindow textWindow)
    {
        int random = Random.Range(0, _noteSpawns.Count);
        GameObject createdNote = Instantiate(note);
        createdNote.transform.position = _noteSpawns[random].position;
        createdNote.transform.rotation = _noteSpawns[random].rotation;
        createdNote.GetComponentInChildren<DistanceCondition>()
            .SetPlayer(player.transform);
        createdNote.transform.SetParent(gameObject.transform);
        int noteId;

        if (journal.CollectedNotes.Count > 0)
            noteId = journal.CollectedNotes.Last() + 1;
        else
            noteId = 3;

        createdNote.GetComponentInChildren<ReadNoteInteraction>()
            .Initialize(noteId, textWindow, handAudioSource, journal);
    }

    public void Initialize(GameObject player)
    {
        DistanceCondition[] distanceConditions
            = GetComponentsInChildren<DistanceCondition>();

        foreach (DistanceCondition distanceCondition in distanceConditions)
            distanceCondition.SetPlayer(player.transform);
    }
}