using UnityEngine;

namespace Level
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            CrazyGames.CrazySDK.Game.GameplayStart();
        }
    }
}
