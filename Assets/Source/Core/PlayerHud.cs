using DungeonCrawl.Actors;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    public Text Name;
    public HpBar Hpbar;

    public void SetData(Actor player)
    {

        Name.text = player.DefaultName;
        Hpbar.SetHP((float) player.Health / player.MaxHealth);
    }
}
