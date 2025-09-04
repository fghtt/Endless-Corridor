using UnityEngine;
using Zenject;

public class PlayerRebirth : MonoBehaviour
{
    private PassedCorridorsCount _passedCorridorsCount;
    private LevelGenerator _levelGenerator;

    [Inject]
    private void Consruct(PassedCorridorsCount passedCorridorsCount,
        LevelGenerator levelGenerator)
    {
        _passedCorridorsCount = passedCorridorsCount;
        _levelGenerator = levelGenerator;
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}