using UnityEngine;
using System.Collections.Generic;

public class Journal : MonoBehaviour
{
	[SerializeField]
	private Saves _saves;

	private List<int> _collectedNotes = new List<int>();
	public List<int> CollectedNotes => _collectedNotes;

	private int _currentReadingNote;

    private void Awake()
    {
		if (_saves.GetSaves() != null)
			_collectedNotes = _saves.GetSaves()._collectedNotes;
    }

    public void AddNote(int id)
	{
		_collectedNotes.Add(id);
	}

	public void ShowJournal()
	{
		
	}
}