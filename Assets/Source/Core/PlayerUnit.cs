using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors;
using DungeonCrawl.Core;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class PlayerUnit : MonoBehaviour
{
    public Actor Unit;
    public void Setup(int id)
    {
        GetComponent<Image>().sprite = ActorManager.Singleton.GetSprite(id);
    }
}