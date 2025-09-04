using UnityEngine;

public class ReadNoteInteraction : Interaction
{
	[SerializeField]
	private int _noteId;

	[SerializeField]
	private TextWindow _textWindow;

    [SerializeField]
    private AudioSource _handAudioSource;

    [SerializeField]
    private Journal _journal;

    private bool _wasPickedUp;
    public bool WasPickedUp => _wasPickedUp;

    public void Initialize(int noteId, TextWindow textWindow,
        AudioSource audioSource, Journal journal)
    {
        _noteId = noteId;
        _textWindow = textWindow;
        _handAudioSource = audioSource;
        _journal = journal;
    }

    public override void Interact()
    {
        _textWindow.Show(_noteId);
        _handAudioSource.Play();
        _journal.AddNote(_noteId);
        _wasPickedUp = true;
        Destroy(gameObject);
    }

    public void InteractWithoutTextWindow()
    {
        _wasPickedUp = true;
        gameObject.SetActive(false);
    }
}