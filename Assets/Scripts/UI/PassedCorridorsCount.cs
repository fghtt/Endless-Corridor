using UnityEngine;
using TMPro;
using Zenject;

public class PassedCorridorsCount : MonoBehaviour
{
	private TextMeshProUGUI _countText;
    private CorridorsGenerator _corridorsGenerator;

	private int _countValue;
    public int CountValue => _countValue;

    [Inject]
    private void Construct(CorridorsGenerator corridorsGenerator)
    {
        _corridorsGenerator = corridorsGenerator;
    }

    private void Awake()
    {
        _countText = GetComponent<TextMeshProUGUI>();
    }

    public void SetCountValue(int countValue)
    {
        if (_countText == null)
            _countText = GetComponent<TextMeshProUGUI>();

        _countValue = countValue;
        _countText.text = _countValue.ToString();
    }

    public void IncreaseCount()
    {
        _countValue++;
        _countText.text = _countValue.ToString();
    }

    public void DecreaseCount()
    {
        _countValue--;
        _countText.text = _countValue.ToString();
    }

    public int GetPassedCordors()
    {
        DecreaseCount();
        int passedCorridors =
            _countValue -
            _countValue % _corridorsGenerator.AmountOfCorridors;

        return passedCorridors;
    }
}