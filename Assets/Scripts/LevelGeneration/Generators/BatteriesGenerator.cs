using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class BatteriesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _battery;
    [SerializeField] private AudioSource _handAudioSource;

    private RoomsGenerator _roomsGenerator;
    private AmountOfBatteriesUI _amountOfBatteries;

    [Inject]
    private void Construct(RoomsGenerator roomsGenerator,
        AmountOfBatteriesUI amountOfBatteries)
    {
        _roomsGenerator = roomsGenerator;
        _amountOfBatteries = amountOfBatteries;
    }

    public void Generate(GameObject player, int index, Corridor corridor)
    {
        int amountOfBatteries = Random.Range(corridor.MinBatteries,
            corridor.MaxBatteries);

        for (int i = 0; i < amountOfBatteries; i++)
        {
            Room room = null;

            while (room == null)
            {
                int random = Random.Range(0,
                    _roomsGenerator.CreatedRooms[index].Count);

                if (!_roomsGenerator.CreatedRooms[index][random].HasBattery)
                    room = _roomsGenerator.CreatedRooms[index][random];
            }

            room.SpawnBattery(_battery, player, _handAudioSource,
                _amountOfBatteries);
        }     
    }
}