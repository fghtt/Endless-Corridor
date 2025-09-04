using UnityEngine;
using Zenject;
using System.Linq;

public class StartRoom : MonoBehaviour
{
	[SerializeField]
	private Transform _exitPoint;
	public Transform ExitPoint => _exitPoint;

	[SerializeField]
    private Exit _createdExit;
    public Exit CreatedExit => _createdExit;

	[SerializeField] private Enter _enter;
    [SerializeField] private GameObject _staticExit;

    private CorridorsGenerator _corridorsGenerator;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator)
    {
        _corridorsGenerator = corridorsGenerator;
    }

    public void MoveStartRoom()
    {
        Corridor firstCorridor = _corridorsGenerator.CreatedCorridors.First();
        GameObject exit = Instantiate(_staticExit);
        exit.transform.SetParent(_corridorsGenerator.CreatedCorridors
            .First().gameObject.transform);
        exit.transform.position = firstCorridor.EnterPoint.position;
        Corridor lastCorridor = _corridorsGenerator.CreatedCorridors.Last();
        gameObject.transform.position = lastCorridor.ExitPoint.position;
        _enter.Activate();
        _createdExit.Activate();
    }
}