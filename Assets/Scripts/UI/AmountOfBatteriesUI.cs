using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class AmountOfBatteriesUI : MonoBehaviour
{
	[SerializeField]
	private GameObject _batteryUIPrefab;

	private List<Slider> _batteries = new List<Slider>();

	public int BatteriesCount => _batteries.Count;

    private void Start()
    {
		AddBattery();
        AddBattery();
        AddBattery();
        AddBattery();
    }

    public void AddBattery()
	{
		GameObject batteryUi = Instantiate(_batteryUIPrefab);
		batteryUi.transform.SetParent(gameObject.transform);
		_batteries.Add(batteryUi.GetComponent<Slider>());
	}

	public void RemoveBattery()
	{
        GameObject slider = _batteries.First().gameObject;
        _batteries.RemoveAt(0);
        Destroy(slider);
    }

	public void ChangeCurrentBatteryPower(float sliderValue)
	{
		_batteries.First().value = sliderValue;
	}
}