using UnityEngine;

public class RoomPoint : MonoBehaviour
{
    public enum RotationOptions
    {
        Degrees0 = 0,
        Degrees90 = 90,
        Degrees180 = 180,
        Degrees270 = 270
    };

    [SerializeField]
    private RotationOptions _rotation;
    public RotationOptions Rotation => _rotation;
}