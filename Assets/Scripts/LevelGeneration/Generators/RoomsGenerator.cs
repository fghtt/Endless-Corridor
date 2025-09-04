using UnityEngine;
using System.Collections.Generic;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _rooms;

    private Dictionary<int, List<Room>> _createdRooms
        = new Dictionary<int, List<Room>>();
    public Dictionary<int, List<Room>> CreatedRooms => _createdRooms;

    private List<int> _createdRoomsIndexes = new List<int>();
    private int _creatingRoomIndex;

    public void Generate(GameObject player, int corridorIndex,
        Corridor corridor)
	{
        _createdRooms = new Dictionary<int, List<Room>>();
        _createdRoomsIndexes = new List<int>();

        foreach (RoomPoint roomPoint in corridor.RoomPoints)
        {
            GameObject creatingRoom = DetermineRoom(_rooms);
            GameObject createdRoom = Instantiate(creatingRoom);
            createdRoom.transform.position
                = roomPoint.gameObject.transform.position;
            createdRoom.transform.Rotate(Vector3.up, (float)roomPoint.Rotation);
            Room room = createdRoom.GetComponent<Room>();
            room.Initialize(player);
            createdRoom.transform.SetParent(corridor.transform);

            if (!_createdRooms.ContainsKey(corridorIndex))
                _createdRooms.Add(corridorIndex, new List<Room>());

            _createdRooms[corridorIndex].Add(room);

            if (room.CreateMonsterAction != null)
                room.CreateMonsterAction
                    .Initialize(corridorIndex);
        }
    }

    private GameObject DetermineRoom(List<GameObject> rooms)
    {
        int amountOfRooms = rooms.Count;

        _creatingRoomIndex = Random.Range(0, amountOfRooms);

        foreach (int roomIndex in _createdRoomsIndexes)
        {
            if (_creatingRoomIndex == roomIndex)
                return DetermineRoom(rooms);
        }

        _createdRoomsIndexes.Add(_creatingRoomIndex);
        return rooms[_creatingRoomIndex];
    }

}