using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelDestroyer : MonoBehaviour
{
    private LevelGenerator _levelGenerator;
    private CorridorsDestroyer _corridorsDestroyer;

    [Inject]
    private void Construct(LevelGenerator levelGenerator)
    {
        _levelGenerator = levelGenerator;
    }

    private void Start()
    {
        _corridorsDestroyer = GetComponent<CorridorsDestroyer>();
    }

    public void Destroy()
    {
        _corridorsDestroyer.Destroy();
    }
}