using UnityEngine;
using Zenject;
using System.Linq;

public class CorridorsDestroyer : MonoBehaviour
{
    private CorridorsGenerator _corridorsGenerator;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator)
    {
        _corridorsGenerator = corridorsGenerator;
    }

    public void Destroy()
    {
        _corridorsGenerator.CreatedCorridors.First().ClearNavMesh();

        foreach (GameObject corridor in _corridorsGenerator.CreatedCorridorsObjects)
        {
            Destroy(corridor);
        }
    }
}