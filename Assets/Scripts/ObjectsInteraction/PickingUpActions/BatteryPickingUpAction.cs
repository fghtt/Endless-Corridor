using UnityEngine;

public class BatteryPickingUpAction : PickingUpAction
{
    [SerializeField]
    private AmountOfBatteriesUI _amountOfBatteries;

    [SerializeField]
    private AudioSource _handAudioSource;

    public void Initialize(AmountOfBatteriesUI amountOfBatteries,
        AudioSource audioSource)
    {
        _amountOfBatteries = amountOfBatteries;
        _handAudioSource = audioSource;
    }

    public override void PerformAnAction()
    {
        _handAudioSource.Play();
        _amountOfBatteries.AddBattery();
    }
}