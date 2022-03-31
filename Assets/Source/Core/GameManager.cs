using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            var cams = GameObject.FindObjectsOfType(typeof(Camera));
            foreach (Camera cam in cams)
            {
                if (cam.name == "BattleCamera")
                {
                    cam.enabled = false;
                }
            }
            MapLoader.LoadMap(1);
        }
    }
}
