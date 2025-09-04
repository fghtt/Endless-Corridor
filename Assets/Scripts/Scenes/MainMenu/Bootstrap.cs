using UnityEngine;

namespace Menu
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            CrazyGames.CrazySDK.Game.GameplayStart();
        }
    }
}
