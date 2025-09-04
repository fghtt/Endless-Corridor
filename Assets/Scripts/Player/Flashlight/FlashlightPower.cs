using UnityEngine;
using UnityEngine.UI;

public class FlashlightPower : MonoBehaviour
{
	[SerializeField]
	private float _batteryLifeTime;

	[SerializeField]
	private Slider _slider;

	[SerializeField]
	private AmountOfBatteriesUI _amountOfBatteries;

	[SerializeField]
    private float _noPowerIntensity;

	[SerializeField]
	private Light _spotLight;

	[SerializeField]
	private PlayerFlashlight _playerFlashlight;

    private float _passedTime;
	private bool _hasPower => _passedTime < _batteryLifeTime;

	public bool HasPower => _amountOfBatteries.BatteriesCount > 0;

    private void Update()
    {
		if (_amountOfBatteries.BatteriesCount > 0)
		{
            if (_playerFlashlight.IsActivated)
			{
	
                _passedTime += Time.deltaTime;
                ShowOnSlider();

                if (!_hasPower)
                    Recharge();
            }
		}
		else
			_spotLight.intensity = _noPowerIntensity;
    }

	private void Recharge()
	{
		_passedTime = 0;
		_amountOfBatteries.RemoveBattery();		
    }

    private void ShowOnSlider()
	{
		float currentPercent = _passedTime / (_batteryLifeTime / 100);
		float sliderValue = _slider.maxValue - currentPercent / 100;

        _slider.value = sliderValue;
		_amountOfBatteries.ChangeCurrentBatteryPower(sliderValue);
	}

	public void DecreasePower(float seconds)
	{
		if (HasPower)
			_passedTime += seconds;
	}
}