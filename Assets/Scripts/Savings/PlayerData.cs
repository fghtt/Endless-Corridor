using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public const string PASSED_CORIDORS_COUNT_KEY = "passedCorridors";
    public const string HAS_STARTED_GAME = "hasStartedGame";

    public int _passedCorridorsCount;
    public bool _hasStartedGame;
    public List<int> _collectedNotes;

    public void Initialize(int passedCorridors, bool hasStartedGame,
        List<int> collectedNotes)
    {
        _passedCorridorsCount = passedCorridors;
        _hasStartedGame = hasStartedGame;
        _collectedNotes = collectedNotes;
    }
}