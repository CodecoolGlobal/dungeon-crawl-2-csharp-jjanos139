using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUnit : MonoBehaviour
{
    public Actor Unit;
    public void Setup(int id)
    {
        GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(id);
    }
}